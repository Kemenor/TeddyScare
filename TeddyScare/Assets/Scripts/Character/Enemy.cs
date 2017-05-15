using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character {
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
            Vector2 vec = new Vector2(1,1);
            vec = Rotate(vec, 90);
            Debug.DrawLine(transform.position, vec, Color.blue);
            Vector2 direction = (target.transform.position - transform.position).normalized;
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

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    public Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

}
