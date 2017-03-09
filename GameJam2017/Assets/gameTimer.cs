using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTimer : MonoBehaviour {

	public float gameTime;
	public float drawTime;

	public PlayerHand playersHand;

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
	}
	
	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;
		drawTime += Time.deltaTime;
		if (drawTime > 15.0f) {
			//playersHand.DrawNewCard ();
			drawTime = 0;
		}
	}
}
