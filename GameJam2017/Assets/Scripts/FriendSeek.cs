using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSeek : MonoBehaviour {

	public float vocalRadius = 0;
	private List<PersonColourControl> inRadius;
	private Rigidbody2D me;
	private PersonMovement personMoving;

	// Use this for initialization
	void Start () {
		inRadius = new List<PersonColourControl>();
		me = GetComponent<Rigidbody2D> ();
		personMoving = GetComponent<PersonMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		//Finds all colliders in a radius and adds them to list
		foreach( Collider2D p in Physics2D.OverlapCircleAll(transform.position, vocalRadius))
		{
			inRadius.Add(p.transform.GetComponent<PersonColourControl>());
		}
		//For each person in range, add colours to them
		for(int i = 0; i < inRadius.Count; i++)
		{
			Vector2 desiredVel = (inRadius [i].transform.position - transform.position).normalized * personMoving.maxSpeed;
			personMoving.dir+=(desiredVel - me.velocity);
		}


		inRadius.Clear();
		
	}
}
