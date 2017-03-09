using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour {

	public string title; //Card Title - UI Text is set from the actual text object.
	public string flavorText; //Card Flavor Text - UI Text is set from the actual text object.
	public List<CardEffects.EffectType> effectTypes; //Can be set in the editor
	public List<float> effectRadius; //Can be set in the editor - Corresponds to effectType of the same index
	public List<float> effectStrength; //Can be set in the editor - Corresponds to effectType of the same index
	public float rarity = 0; //Value between 0 and 10 to deal with how commonly drawn it is. Higher is more common.

	CardEffects Effects; //Shifted card effects to a custom class to make them easier to call later.
	bool waitingForAction = false;
	void Start () {
		Effects = new CardEffects (effectTypes, effectRadius, effectStrength);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivateCard(){
		if (!waitingForAction) {
			StartCoroutine (CastCard ());
		}
	}

	IEnumerator CastCard(){
		waitingForAction = true;
		while (waitingForAction) {
			if (Input.GetMouseButton (0)) {
				//Activate card as location
			}
			if (Input.GetMouseButton (1)) {
				//Cancel Card action - return to hand
				Debug.Log("Right Click Detected!");
				waitingForAction = false;
				GameObject.Find ("PlayerHand").GetComponent<PlayerHand> ().reorganiseHand = true;
			}
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			transform.position = ray.origin;
			yield return new WaitForEndOfFrame();
		}
	}
}
