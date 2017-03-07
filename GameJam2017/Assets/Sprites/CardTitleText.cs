using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTitleText : MonoBehaviour {

	private CardBehaviour parent;

	void Start () {
		parent = transform.parent.GetComponent<CardBehaviour> ();
		GetComponent<Text> ().text = parent.title;
	}
}
