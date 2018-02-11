using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimerUI : MonoBehaviour {

    GameManager gameManager;
    Text text;

	// Use this for initialization
	void Start () {
        text = FindObjectOfType<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager == null)
            {
                // game hasn't started yet
                return;
            }
        }
        text.text = gameManager.TimeLeft.ToString("#.00");
	}
}
