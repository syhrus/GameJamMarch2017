using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour {

	private RectTransform mainCard;
	private GUIText cardTitle;
	private Vector2 smallSize;
	private Vector2 bigSize;

	void Start () {
		mainCard = transform.GetComponent<RectTransform>();
		cardTitle = GetComponentInChildren<GUIText>();
		smallSize = mainCard.rect.size;
		bigSize = mainCard.rect.size * 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		Event e = Event.current;
		if (mainCard.rect.Contains (e.mousePosition)) {
			mainCard.sizeDelta = bigSize;
		} else {
			mainCard.sizeDelta = smallSize;
		}
	}
}
