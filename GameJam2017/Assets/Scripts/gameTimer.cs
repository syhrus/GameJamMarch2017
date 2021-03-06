﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTimer : MonoBehaviour {

	public float gameTime;
	public float drawTime;

	public PlayerHand playersHand;
    public PlayerHand enemyHand;

	// Use this for initialization
	void Start () {
		gameTime = 0;
		drawTime = 0;
		//playersHand = GameObject.Find ("PlayerHand").GetComponent<PlayerHand> ();
		playersHand.DrawNewCard();
		playersHand.DrawNewCard();
		playersHand.DrawNewCard();
		playersHand.DrawNewCard();
		playersHand.DrawNewCard();
        enemyHand.DrawNewCard();
        enemyHand.DrawNewCard();
        enemyHand.DrawNewCard();
        enemyHand.DrawNewCard();
        enemyHand.DrawNewCard();
    }
	
	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;
		drawTime += Time.deltaTime;
		if (drawTime > 10.0f) {
            if (playersHand.cards.Count < playersHand.maxhand)
            {
                playersHand.DrawNewCard();
                enemyHand.DrawNewCard();

            }
            drawTime = 0;
		}
	}
}
