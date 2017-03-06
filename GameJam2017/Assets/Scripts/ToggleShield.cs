using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShield : MonoBehaviour {

    public List<PersonColourControl> greenShielded;
    public List<PersonColourControl> redShielded;
    public float shieldon = 1;

    public void ToggleAllShields()
    {
        if (shieldon == 1)
        {
            shieldon = 0;
        }else
        {
            shieldon = 1;
        }
        for (int i = 0; i < greenShielded.Count; i++)
        {
            greenShielded[i].borderGreen = shieldon;
        }
        for (int i = 0; i < redShielded.Count; i++)
        {
            redShielded[i].borderRed = shieldon;
        }

    }
}
