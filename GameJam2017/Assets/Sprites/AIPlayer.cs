using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour {

    PlayerHand myHand;

    public float minWait = 4;
    public float maxWait = 10;

    public List<float> playbounds;

	void Start () {
        myHand = GetComponent<PlayerHand>();
        StartCoroutine(AIPlayCards());	
	}
	
	IEnumerator AIPlayCards()
    {
        while (true)
        {
            if (myHand.cards.Count > 0)
            {
                CardBehaviour playcard = myHand.cards[Mathf.RoundToInt(Random.Range(0, myHand.cards.Count))];
                playcard.transform.position = new Vector2(Random.Range(playbounds[0], playbounds[1]), Random.Range(playbounds[2], playbounds[3]));
                yield return new WaitForSeconds(0.5f);
                playcard.AIPlayCard(playcard.transform.position);
                playcard.DiscardCardAI();
            }
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

        }
    }
}
