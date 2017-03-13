using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameovertext : MonoBehaviour {

    private TrackScore parent;

    void Start()
    {
        parent = GameObject.Find("GameTimer").GetComponent<TrackScore>();
    }

    void Update()
    {
        if (parent.gameOver)
        {
            GetComponent<Text>().text = parent.gameOverText;
        }
    }
}
