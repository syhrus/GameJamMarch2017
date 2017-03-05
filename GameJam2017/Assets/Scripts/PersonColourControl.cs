﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonColourControl : MonoBehaviour {

    //Inner Colours
    public float green = 0;
    public float red = 0;
    private float grey = 0.5f;

    //Border Colours
    public float borderGreen = 0; 
    public float borderRed = 0;

    private SpriteRenderer border; //Border Sprite of person
    private SpriteRenderer inner; //Inner Sprite of person

	void Start () {
        //Get border and inner sprites.
        border = transform.FindChild("Border").GetComponent<SpriteRenderer>();
        inner = transform.FindChild("Inner").GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        //Border initially removes all other colour's power
        if(borderGreen > 0)
        {
            red = 0;
        }
        if (borderRed > 0)
        {
            green = 0;
        }

        //clamp colour values so they don't get too large - This also adds a little bit of a decay factor, so that's nice.
        while (red + green > 1)
        {
            red /= 2;
            green /= 2;
        }
        grey = 0.5f - red/2 - green/2;

        borderGreen = Mathf.Clamp01(borderGreen);
        borderRed = Mathf.Clamp01(borderRed);

        //set inner colour 
        inner.color = new Color(
               Mathf.Clamp01(grey + red),
               Mathf.Clamp01(grey + green),
               grey
               );
        //set border colour 
        border.color = new Color(
               borderRed,
               borderGreen,
               0.0f
               );
    }
}