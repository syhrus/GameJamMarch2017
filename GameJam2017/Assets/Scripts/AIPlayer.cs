using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steven : MonoBehaviour {

    PlayerHand myHand;
    TrackScore game;

    public float minWait = 4;
    public float maxWait = 10;

    public List<float> playbounds;

	void Start () {
        myHand = GetComponent<PlayerHand>();
        game = GameObject.Find("GameTimer").GetComponent<TrackScore>();
        StartCoroutine(AIPlayCards());	
	}
	
	IEnumerator AIPlayCards()
    {
        while (!game.gameOver)
        {
            if (myHand.cards.Count > 0)
            {
                CardBehaviour playcard = myHand.cards[Mathf.RoundToInt(Random.Range(0, myHand.cards.Count))];
                playcard.transform.position = new Vector2(Random.Range(playbounds[2], playbounds[3]), Random.Range(playbounds[0], playbounds[1]));
                yield return new WaitForSeconds(0.5f);
                playcard.AIPlayCard(playcard.transform.position);
                playcard.DiscardCardAI();
            }
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

        }
    }
}
