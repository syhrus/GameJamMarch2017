using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonColourControl : MonoBehaviour {

    //Inner Colours
    public float blue = 0;
    public float red = 0;
    private float grey = 0.5f;

    //Border Colours
    public float borderBlue = 0; 
    public float borderRed = 0;

    private SpriteRenderer border; //Border Sprite of person
    private SpriteRenderer inner; //Inner Sprite of person

	void Start () {
        //Get border and inner sprites.
        border = transform.FindChild("Border").GetComponent<SpriteRenderer>();
        inner = transform.FindChild("Inner").GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        //clamp colour values so they don't get too large - This also adds a little bit of a decay factor, so that's nice.
        while (red + blue > 1)
        {
            red /= 2;
            blue /= 2;
        }
        grey = 0.5f - red - blue;

        borderBlue = Mathf.Clamp01(borderBlue);
        borderRed = Mathf.Clamp01(borderRed);

        //set inner colour 
        inner.color = new Color(
               grey + red,
               grey,
               grey + blue
               );
        //set border colour 
        border.color = new Color(
               0.0f + (borderRed),
               0.0f,
               0.0f + (borderBlue)
               );
    }
}
