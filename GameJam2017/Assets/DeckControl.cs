using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckControl : MonoBehaviour {

	public List<GameObject> cards; //List of card Prefabs

	public GameObject selectRandomCard(){
		//Picks a random card and checks against a random seed to simulate rarity.
		float seed = Random.value * 10.0f;
		bool selected = false;
		GameObject card = null;
		int i = 0; //Stops accidentally getting stuck in a loop
		while (!selected || i>10) {
			int rando = Random.Range (0, cards.Count);
			card = cards [rando];
			if (card.GetComponent<CardBehaviour>().rarity > seed) {
				selected = true;
			}
			i++;
		}
		if(card == null){
			return selectRandomCard ();
		}else{
			return card;
		}
	}
}
