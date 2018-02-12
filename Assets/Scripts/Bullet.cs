using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

    Rigidbody2D myRb;

    public float Radius = 2f;
    public float Damage = 10f;
    public bool DamageFallsOff = true;
    public GameObject SourceTank; // who shot this bullet?

	// Use this for initialization
	void Start () {
        myRb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float angle = Mathf.Atan2(myRb.velocity.y, myRb.velocity.x) * Mathf.Rad2Deg;
        myRb.rotation = angle;

        if (isServer)
        {
            // check for ground collisions
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isServer)
        {
            // only the server handles explosions
            return;
        }

        // we hit something

        // is this our tank? don't detonate

        // if we get here, go boom

    }
}
