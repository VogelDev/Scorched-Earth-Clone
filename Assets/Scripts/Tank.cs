using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Tank : NetworkBehaviour {

    // This script will run on ALL clients AND on the server
    // Additionally, one of the clients may be the local authority

    // SyncVars?
    float MovementPerTurn = 5;
    float MovementLeft;
    float Speed = 5;

    [SyncVar]
    Vector3 serverPosition;

    Vector3 serverPositionSmoothVelocity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isServer)
        {
            // Maybe we need to check server specific stuff?
        }

        if (hasAuthority)
        {
            // this is MY object
            AuthorityUpdate();
        }

        // do generic updates for ALL clients/server

        // are we in the correct position
        if (!hasAuthority)
        {
            // we don't own this object, so we better let the server decide

            transform.position = Vector3.SmoothDamp(transform.position, serverPosition, ref serverPositionSmoothVelocity, .25f);
        }
	}

    void AuthorityUpdate()
    {
        // Listen for keyboard commands for movement
        float movement = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        // TODO: track movement left


        // We have authority, and we don't want input lag -- move the sprite and let the server catch up later if it's wrong
        transform.Translate(movement, 0, 0);

        // Do we manually tell the network where we moved?
        CmdUpdatePosition(transform.position);

    }

    void NewTurn()
    {
        // run on server? SyncVars?
        MovementLeft = MovementPerTurn;
    }

    [Command]
    void CmdUpdatePosition(Vector3 position)
    {
        // TODO: check to make sure this move is legal, landscape/move distance
        // if an illegal move is spotted:
        // RpcFixPosition(serverposition); return;
        serverPosition = position;
    }

    [ClientRpc]
    void RpcFixPosition(Vector3 position)
    {
        // server says your location is bad, fix it
        // did the client move illegally?
        transform.position = position;

    }
}
