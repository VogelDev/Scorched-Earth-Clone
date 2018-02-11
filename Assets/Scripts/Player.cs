using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    public GameObject TankPrefab;

	// Use this for initialization
	void Start ()
    {
        // FOR NOW -- spawn a player's tank as soon as they connect
        // when they die, they respawn in 3 seconds
        if (isServer)
        {
            SpawnTank();
        }
	}

    // Update is called once per frame
    void Update()
    {

    }

    //This script represents a connected player who might "own" other 
    //objects in the game

    /// <summary>
    /// Gets called by game manager when a new round starts
    /// </summary>
    public void SpawnTank()
    {
        if (!isServer)
        {
            Debug.LogError("SpawnTank should only be called on the server");
            return;
        }

        // TODO: Consider the player has some custom settings

        // spawns on client without telling anyone
        GameObject go = Instantiate(TankPrefab);

        NetworkServer.Spawn(go);

    }
}
