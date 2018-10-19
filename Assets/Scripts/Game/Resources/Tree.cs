using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Harvestable {

	[SerializeField]
	private Animator animator;
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("Being Worked", beingWorked);
		animator.SetBool ("Felled", life == 0);
	}
}
