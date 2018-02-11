using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    [SyncVar]
    public float TimeLeft = 180; // 3 minutes * 60 seconds/minute

	// Use this for initialization
	void Start () {
		// NOTE: Start runs before anyone connects to any server
	}
	
	// Update is called once per frame
	void Update () {

        if (!isServer)
        {
            return;
        }

        // FOR NOW -- we just reset the map/players every 3 minutes
        TimeLeft -= Time.deltaTime;
        if(TimeLeft <= 0)
        {
            // restart?
        }
	}


}
