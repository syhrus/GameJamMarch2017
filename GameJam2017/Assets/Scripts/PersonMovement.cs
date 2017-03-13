using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour {

	public float maxSpeed = 5; //adjustable speed
	public Vector2 dir;
	private Vector2 force;
	private Rigidbody2D me;

	// Use this for initialization
	void Start () {
		me = GetComponent<Rigidbody2D> ();
		dir = Vector2.zero;
	}

	// Update is called once per frame
	void Update () {
		force = Vector2.ClampMagnitude (dir, maxSpeed);

	}

	void FixedUpdate(){
		me.AddForce (force);
	}

    public void StartAttractTo(Vector2 location, int repetitions, float weight)
    {
        StartCoroutine(AttractTo(location, repetitions, weight));
    }

    IEnumerator AttractTo(Vector2 location, int repetitions, float weight)
    {
        int i = 0;
        while (i < repetitions)
        {
            dir += (location - new Vector2(transform.position.x, transform.position.y)).normalized * maxSpeed * weight;
            yield return new WaitForSeconds(0.1f);
            i++;
        }
    }
}
