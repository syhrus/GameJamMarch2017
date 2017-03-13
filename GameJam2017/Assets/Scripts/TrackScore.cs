using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackScore : MonoBehaviour {

	public int redScore = 0;
	public int greenScore = 0;
	private int countRed = 0;
	private int countGreen = 0;
	private List<PersonColourControl> allPeople;
	private GameObject peopleHolder;

	public string gameOverText;
	public string restartText;


	public bool gameOver;
	private bool restart;

	// Use this for initialization
	void Start () {
		allPeople = new List<PersonColourControl>();
		peopleHolder = GameObject.Find ("People");
		//creates a list of every person in the game
		foreach (Transform t in peopleHolder.transform) {
			allPeople.Add(t.GetComponent<PersonColourControl>());
		}

		gameOver = false;
		restart = false;

		gameOverText = "";
		restartText = "";

		StartCoroutine (ScoreGet ());
	}

	void Update(){

		if (gameOver) {
			restartText = "'R'estart";
			restart = true;
		}

		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Scene scene = SceneManager.GetActiveScene ();
				SceneManager.LoadScene (scene.name);
			}
				
		}

	}

	
	// coroutine called every 5 seconds
	IEnumerator ScoreGet () {

		while (!gameOver) {

			for (int i = 0; i < allPeople.Count; i++) {
				if (allPeople [i].red > allPeople [i].green) {//if red increase red score
					countRed++;
				} else if (allPeople [i].red < allPeople [i].green) {//if green increase green score
					countGreen++;
				}
			}

			redScore = countRed;
			if (redScore == 0) {
				//win game code goes here
				gameOverText ="You have won welcome to your new Utopia.";
				gameOver = true;
			}
			greenScore = countGreen;
			if (greenScore == 0) {
				//lose game code goes here
				gameOverText ="The Fascists have won. Flee to Canada?";
				gameOver = true;
			}
			countRed = 0;
			countGreen = 0;

			yield return new WaitForSeconds (5);
		}
	}
}
