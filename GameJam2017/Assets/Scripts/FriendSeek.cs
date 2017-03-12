using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSeek : MonoBehaviour {

	public float seekRadius = 0;
	private List<PersonColourControl> inRadius;
	private PersonColourControl meColour;
	private Rigidbody2D meBody;
	private PersonMovement personMoving;
	private int myColour = 0; //will be set to know persons colour 1 if red 2 if not red
	private int targetColour = 0;

	// Use this for initialization
	void Start () {
		inRadius = new List<PersonColourControl>();
		meBody = GetComponent<Rigidbody2D> ();
		meColour = GetComponent<PersonColourControl> ();
		personMoving = GetComponent<PersonMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		//checks my colour
		if (meColour.red > meColour.green) {
			myColour = 1;
		} else {
			myColour = 2;
		}
		//Finds all colliders in a radius and adds them to list
		foreach( Collider2D p in Physics2D.OverlapCircleAll(transform.position, seekRadius))
		{
			inRadius.Add(p.transform.GetComponent<PersonColourControl>());
		}
		//For each person in range, add colours to them
		for(int i = 0; i < inRadius.Count; i++)
		{
			//checks targets colour
			if (inRadius[i].red >= inRadius[i].green) {
				targetColour = 1;
			} else {
				targetColour = 2;
			}

			if (targetColour != myColour) {//we are different colours

				Vector2 desiredVel = (inRadius [i].transform.position - transform.position).normalized * personMoving.maxSpeed;
				personMoving.dir -= (desiredVel - meBody.velocity);

			} else {//else we are similar colours

				Vector2 desiredVel = (inRadius [i].transform.position - transform.position).normalized * personMoving.maxSpeed;
				personMoving.dir += (desiredVel - meBody.velocity);

			}
		}


		inRadius.Clear();
		
	}
}
