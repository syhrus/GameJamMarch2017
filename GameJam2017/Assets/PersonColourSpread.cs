using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonColourSpread : MonoBehaviour {

    public float vocalRadius = 0; //Radius of trigger
    public float changepower = 0.01f; //Amount of change per cycle
    public float changeRate = 10; //Tweaker for rate of change

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
            foreach( Collider2D p in Physics2D.OverlapCircleAll(transform.position, vocalRadius))
            {
                inRadius.Add(p.transform.GetComponent<PersonColourControl>());
            }
            //For each person in range, add colours to them
            for(int i = 0; i < inRadius.Count; i++)
            {
                PersonColourControl person = inRadius[i];
                person.green += thisColours.green * changepower;
                person.red += thisColours.red * changepower;
            }

            yield return new WaitForSeconds(changeRate);
            inRadius.Clear();
        }
    }
}
