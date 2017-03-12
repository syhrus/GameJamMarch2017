using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles Player's Hand
public class PlayerHand : MonoBehaviour {

	public List<CardBehaviour> cards;
	public int maxhand = 5;

	public DeckControl deck;
	public bool reorganiseHand = true;

	void Start () {
		//deck = GameObject.Find ("PlayerDeck").GetComponent<DeckControl> ();
	}

	void Update () {
		if (reorganiseHand) {
			//Sort the hand and position transforms correctly.
			Debug.Log("Reorganising hand");
			float width = transform.GetComponent<RectTransform>().rect.width;
			width *= 0.9f; //Leave margin for hand sides
			float widthpercard = width / cards.Count;
			float position = width * 0.05f;

			foreach (CardBehaviour card in cards) {
				Debug.Log ("Moving card to: " + position);
				RectTransform thisrect = card.transform.GetComponent<RectTransform> ();
				thisrect.anchoredPosition = new Vector2(position, 110.0f);
				position += widthpercard;
			}

			reorganiseHand = false;
		}
	}

	public void DrawNewCard(){
		//Create new card object and add behaviour to hand.
		GameObject newCard = Instantiate (deck.selectRandomCard (), transform);
		newCard.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1); //Not sure why, but it defaults to a massive scale. This fixes that.

		cards.Add (newCard.GetComponent<CardBehaviour>());
		reorganiseHand = true;
	}

	public void DiscardCard(Transform card){

	}
}
