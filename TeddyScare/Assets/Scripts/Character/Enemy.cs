using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character {

    protected bool dead = false;
    public bool LineOfSightToPlayer(float muliplier = 1f)
    {
        Player instance = Game.Player;
        if (instance.Anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            return false;
        }
        return LineOfSight(instance.GetComponent<Collider2D>(), muliplier);
    }

    public bool LineOfSight(Collider2D target, float muliplier = 1f)
    { 
        if (visible)
        {
            Vector2 direction = GetDirection(target);
            float angle = Vector2.Angle(facingRight ? transform.right : transform.right * -1, direction);
            Debug.DrawRay(transform.position, direction * lookingDistance * muliplier, Color.red);
            if (angle <= fov)
            {
                RaycastHit2D sightTest = Physics2D.Raycast(transform.position, direction, lookingDistance * muliplier);
                if (sightTest.collider != null && sightTest.collider.gameObject == target.gameObject)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public override void Reset()
    {
        base.Reset();
        dead = false;
    }

    public Vector2 GetDirection(Collider2D target)
    {
        return (target.transform.position - transform.position).normalized;
    }
    private bool visible;
    private void OnBecameInvisible()
    {
        visible = false;
    }

    private void OnBecameVisible()
    {
        visible = true;
    }
    [SerializeField]
    private float fov;

    [SerializeField]
    private float lookingDistance;

    public void Move()
    {
        transform.Translate(GetDirection() * movementSpeed * Time.deltaTime);
    }

    public void Run()
    {
        transform.Translate(GetDirection() * runSpeed * Time.deltaTime);
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerenter2D(collision);
    }

    protected virtual void OnTriggerenter2D(Collider2D collision)
    {
        if (collision.tag == "Claw")
        {
            dead = true;
            die();
        }
    }

    protected abstract void die();

    public bool OverlapsPlayer()
    {
        Player instance = Game.Player;
        if (instance.Anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            return false;
        }
        
        return GetComponent<Collider2D>().bounds.Intersects(instance.GetComponent<Collider2D>().bounds);
    }

}
