using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
    public Animator Anim { get; protected set; }

    [SerializeField]
    protected float movementSpeed;
    protected bool facingRight;

    protected Vector2 startPos;

    public bool Attack { get; set; }
    // Use this for initialization
    // Use this for initialization
    public virtual void Start()
    {
        facingRight = true;
        Anim = GetComponent<Animator>();
        startPos = transform.position;
    }

    public virtual void Reset()
    {
        transform.position = startPos;
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
