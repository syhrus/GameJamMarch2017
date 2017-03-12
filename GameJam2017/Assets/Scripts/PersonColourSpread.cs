using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonColourSpread : MonoBehaviour {

    public float vocalRadius = 0; //Radius of trigger
    public float changepower = 0.01f; //Amount of change per cycle
    public float changeRate = 10; //Tweaker for rate of change
    public float shieldDecay = 0.001f;

    private List<PersonColourControl> inRadius;
    private PersonColourControl thisColours; //To get current colour

	void Start () {
        inRadius = new List<PersonColourControl>();
        thisColours = GetComponent<PersonColourControl>();

        StartCoroutine(SpreadColour());
    }

    //Running as coroutine to save performance
    IEnumerator SpreadColour()
    {
        while (true) //TODO: Add global "is game running?" variable to check off
        {
            //Finds all colliders in a radius and adds them to list
            foreach (Collider2D p in Physics2D.OverlapCircleAll(transform.position, vocalRadius))
            {
                if (p.tag == "Person")
                {
                    inRadius.Add(p.transform.GetComponent<PersonColourControl>());
                }
            }
            //For each person in range, add colours to them
            for (int i = 0; i < inRadius.Count; i++)
            {
                PersonColourControl person = inRadius[i];
                person.green += thisColours.green * changepower;
                person.red += thisColours.red * changepower;
            }
			float difference = Mathf.Abs (thisColours.green - thisColours.red);
			if (thisColours.green > 0.05f && thisColours.red > 0.05f && difference < 0.1f) {
				//Add more decay when in a middle-ground area
				thisColours.green *= difference;
				thisColours.red *= difference;
			}
            thisColours.borderGreen -= shieldDecay;
            thisColours.borderRed -= shieldDecay;

            yield return new WaitForSeconds(changeRate);
            inRadius.Clear();
        }
    }
}
