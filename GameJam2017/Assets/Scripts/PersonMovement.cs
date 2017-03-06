using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour {

	public float maxSpeed = 10; //adjustable speed
	public Vector2 dir;
	private Rigidbody2D me;

	// Use this for initialization
	void Start () {
		me = GetComponent<Rigidbody2D> ();
		dir = Vector2.zero;
	}

	// Update is called once per frame
	void Update () {
		me.AddForce(dir);
	}
}
