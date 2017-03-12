using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSeek : MonoBehaviour {

	public float seekRadius = 0;
	private List<PersonColourControl> inRadius;
    private List<Transform> nearBorders;
	private PersonColourControl meColour;
	private Rigidbody2D meBody;
	private PersonMovement personMoving;
	private int myColour = 0; //will be set to know persons colour 1 if red 2 if not red
	private int targetColour = 0;

    public float friendWeight = 1;
    public float sameWeight = 1;
    public float enemyWeight = 1;
    public float borderWeight = 1;
    public float flockWeight = 1;

	// Use this for initialization
	void Start () {
		inRadius = new List<PersonColourControl>();
		meBody = GetComponent<Rigidbody2D> ();
		meColour = GetComponent<PersonColourControl> ();
		personMoving = GetComponent<PersonMovement>();
        nearBorders = new List<Transform>();
        StartCoroutine(SeekFriends());
	}

    // Update is called once per frame
    IEnumerator SeekFriends()
    {
        while (true)
        {
            //checks my colour
            if (meColour.red > meColour.green)
            {
                myColour = 1;
            }
            else
            {
                myColour = 2;
            }
            //Finds all colliders in a radius and adds them to list
            foreach (Collider2D p in Physics2D.OverlapCircleAll(transform.position, seekRadius))
            {
                if (p.tag == "Person")
                {
                    inRadius.Add(p.transform.GetComponent<PersonColourControl>());
                }
                if (p.tag == "Borders")
                {
                    nearBorders.Add(p.transform);
                }
            }
            //For each person in range, add colours to them
            for (int i = 0; i < inRadius.Count; i++)
            {
                //checks targets colour
                if (inRadius[i].red >= inRadius[i].green)
                {
                    targetColour = 1;
                }
                else
                {
                    targetColour = 2;
                }


                if (meColour.myFriends == inRadius[i].myFriends)
                {
                    if (targetColour != myColour)
                    {//we are different colours

                        Vector2 desiredVel = (inRadius[i].transform.position - transform.position).normalized * personMoving.maxSpeed;
                        personMoving.dir += (desiredVel - meBody.velocity) * friendWeight * enemyWeight;

                    }
                    else
                    {//else we are similar colours

                        Vector2 desiredVel = (inRadius[i].transform.position - transform.position).normalized * personMoving.maxSpeed;
                        personMoving.dir += (desiredVel - meBody.velocity) * friendWeight * sameWeight;

                    }
                }
                if (targetColour != myColour)
                {//we are different colours

                    Vector2 desiredVel = (inRadius[i].transform.position - transform.position).normalized * personMoving.maxSpeed;
                    personMoving.dir -= (desiredVel - meBody.velocity) * enemyWeight;

                }
                else
                {//else we are similar colours

                    Vector2 desiredVel = (inRadius[i].transform.position - transform.position).normalized * personMoving.maxSpeed;
                    personMoving.dir += (desiredVel - meBody.velocity) * sameWeight;

                }

                //Add flock direction (will want to move in the same direction as neighbours)
                Vector2 flockdesiredVel = (inRadius[i].GetComponent<Rigidbody2D>().velocity);
                personMoving.dir += (flockdesiredVel - meBody.velocity) * flockWeight;
            }

            foreach (Transform t in nearBorders)
            {
                Vector2 desiredVel = (t.position - transform.position).normalized * personMoving.maxSpeed;
                personMoving.dir -= (desiredVel - meBody.velocity) * borderWeight;
            }

            nearBorders.Clear();
            inRadius.Clear();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
