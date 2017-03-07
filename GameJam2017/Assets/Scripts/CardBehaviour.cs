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

	CardEffects Effects; //Shifted card effects to a custom class to make them easier to call later.

	void Start () {
		Effects = new CardEffects (effectTypes, effectRadius, effectStrength);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivateCard(){
		StartCoroutine (CastCard());
	}

	IEnumerator CastCard(){
		bool waitingForAction = true;
		while (waitingForAction) {
			if (Input.GetMouseButtonDown (0)) {
				//Activate card as location
			}
			if (Input.GetMouseButtonDown (1)) {
				//Cancel Card action
			}
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			transform.position = ray.origin;
			yield return new WaitForEndOfFrame();
		}
	}
}
