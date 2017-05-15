using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : Enemy {
    private bool run = false;
    public override void Start()
    {
        base.Start();
        facingRight = false;
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        if (LineOfSightToPlayer())
        {
            //Run away
            Game.Instance.AddToDangerLevel();
            Anim.SetFloat("Speed", 1f);
            run = true;
            ChangeDirection();
            Move();
        }
        if (run)
        {
            Move();
        }
    }

    public override void Reset()
    {
        base.Reset();
        gameObject.SetActive(true);
    }
}
