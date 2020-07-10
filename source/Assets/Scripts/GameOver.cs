using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public static bool isPlayerDead;
    private Text gameOverText;

	// Use this for initialization
	void Start () {
        gameOverText = GetComponent<Text> ();
        gameOverText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerDead){
            Time.timeScale = 0;
            gameOverText.enabled = true;

        }
	}
}
