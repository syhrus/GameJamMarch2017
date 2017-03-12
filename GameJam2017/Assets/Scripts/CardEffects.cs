using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffects {
	public enum EffectType { ShieldGreen, ShieldRed, BoostGreen, BoostRed, ReduceGreen, ReduceRed, AttractGreen, AttractRed }; //All possible types of card effects to check against
	public List<EffectType> Effects; //Stores all effects a card may have
	public List<float> EffectStrength; //Stores the strength of each effect.
	public List<float> EffectRadius; //Stored the radius of each effect.

	//Constructor 1 - Single card effect
	public CardEffects (EffectType effect, float strength, float radius){
		this.Effects = new List<EffectType> ();
		this.EffectRadius = new List<float> ();
		this.EffectStrength = new List<float> ();

		this.Effects.Add (effect);
		this.EffectRadius.Add (radius);
		this.EffectStrength.Add (strength);
	}

	//Constructor 2 - Multiple effects
	public CardEffects (List<EffectType> effects, List<float> strength, List<float> radius){
		//Check that lists are the same length - To avoid bugs later. If something has no radius, just make it 0.
		if (effects.Count == strength.Count && effects.Count == radius.Count) {
			this.Effects = effects;
			this.EffectStrength = strength;
			this.EffectRadius = radius;
		} else {
			Debug.Log ("ERROR: Card effect initialised with different list sizes!");
			this.Effects = new List<EffectType> ();
			this.EffectRadius = new List<float> ();
			this.EffectStrength = new List<float> ();
		}
	}

	//Activates the Card at a particular point on the game screen
	public void ActivateCardEffect(CardEffects cardEffects, Vector2 Location){
		//resolve each effect individually.
		int i = 0;
		foreach (EffectType effect in cardEffects.Effects) {
			//Get all people in radius for effect
			List<PersonColourControl> people = new List<PersonColourControl> ();
			foreach (Collider2D p in Physics2D.OverlapCircleAll(Location, cardEffects.EffectRadius[i])) {
                if (p.transform.GetComponent<PersonColourControl>())
                {
                    people.Add(p.transform.GetComponent<PersonColourControl>());
                }
			}
            switch (cardEffects.Effects[i])
            {
                case EffectType.BoostGreen:
                    foreach (PersonColourControl p in people)
                    {
                        p.green += EffectStrength[i];
                    }
                    break;
                case EffectType.BoostRed:
                    foreach (PersonColourControl p in people)
                    {
                        p.red += EffectStrength[i];
                    }
                    break;
                case EffectType.ReduceGreen:
                    foreach (PersonColourControl p in people)
                    {
                        p.green -= EffectStrength[i];
                    }
                    break;
                case EffectType.ReduceRed:
                    foreach (PersonColourControl p in people)
                    {
                        p.red -= EffectStrength[i];
                    }
                    break;
                case EffectType.ShieldGreen:
                    foreach (PersonColourControl p in people)
                    {
                        p.borderGreen += EffectStrength[i];
                    }
                    break;
                case EffectType.ShieldRed:
                    foreach (PersonColourControl p in people)
                    {
                        p.borderRed += EffectStrength[i];
                    }
                    break;
                case EffectType.AttractGreen:
                    foreach (PersonColourControl p in people)
                    {
                        if (p.green > p.red && Mathf.Abs(p.green - p.red) > 0.125f)
                        {
                            p.transform.GetComponent<PersonMovement>().StartAttractTo(Location, (int)EffectStrength[i], 200);
                        }
                    }
                    break;
                case EffectType.AttractRed:
                    foreach (PersonColourControl p in people)
                    {
                        if (p.green < p.red && Mathf.Abs(p.green - p.red) > 0.125f)
                        {
                            p.transform.GetComponent<PersonMovement>().StartAttractTo(Location, (int)EffectStrength[i], 200);
                        }
                    }
                    break;
            }
			i++;
		}
	}

}
