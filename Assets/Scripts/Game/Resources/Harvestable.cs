using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvestable : MonoBehaviour {

	public bool workable;
	public ResourceType type;
	protected bool beingWorked;

	[SerializeField]
	protected int life;
	[SerializeField]
	private float timePerLife;

	float timeToKeepWorking = 0;
	float timeWorked = 0;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (beingWorked) {
			timeToKeepWorking -= Time.fixedDeltaTime;
			if(timeToKeepWorking < 0) {
				beingWorked = false;
				timeToKeepWorking = 0;
			}
		}
	}

	public int work(float deltaT) {
		if (life > 0) {
			beingWorked = true;
			timeToKeepWorking = deltaT;
			timeWorked += deltaT;

			if(timeWorked > timePerLife) {
				timeWorked -= timePerLife;
				life--;
				return 1;
			}

			return 0;
		} else {
			workable = false;
			beingWorked = false;
			timeToKeepWorking = 0;
			life = 0;
			return 0;
		}
	}
}
