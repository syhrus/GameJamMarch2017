using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour {

	private RectTransform mainCard;
	private RectTransform effectCard;
	private GUIText cardTitle;

	void Start () {
		cardTitle = transform.FindChild ("Title").GetComponent<GUIText> ();
		mainCard = transform.GetComponent<RectTransform> ();
		effectCard = transform.FindChild ("Effect").GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){
		effectCard.gameObject.SetActive (true);
	}

	void OnMouseExit(){
		effectCard.gameObject.SetActive (false);
	}
}
