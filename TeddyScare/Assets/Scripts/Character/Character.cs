using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
    public Animator Anim { get; protected set; }

    [SerializeField]
    protected float runSpeed;
    [SerializeField]
    protected float movementSpeed;
    protected bool facingRight;

    public Vector2 StartPos { get; protected set; }

    public bool Attack { get; set; }
    // Use this for initialization
    // Use this for initialization
    public virtual void Start()
    {
        facingRight = true;
        Anim = GetComponent<Animator>();
        StartPos = transform.position;
    }

    public virtual void Reset()
    {
        transform.position = StartPos;
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
