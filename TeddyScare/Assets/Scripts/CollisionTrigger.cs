using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour {
    [SerializeField]
    private BoxCollider2D platform;
    [SerializeField]
    private BoxCollider2D platformTrigger;

    private BoxCollider2D player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(platform, platformTrigger, true);
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
        if(other.gameObject.name == "Player")
        Physics2D.IgnoreCollision(player, platform, true);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
            Physics2D.IgnoreCollision(player, platform, false);
    }
}
