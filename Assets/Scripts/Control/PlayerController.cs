using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

	public CharacterController2D controller;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	void Update() {
		if (active) {
			horizontalMove = Input.GetAxisRaw ("Horizontal");
	
			if (Input.GetButtonDown ("Jump")) {
				jump = true;
			}

			if (Input.GetAxisRaw ("Vertical") < -0.5f) {
				crouch = true;
			} else {
				crouch = false;
			}
		}
	}

	void FixedUpdate() {
		if (active) {
			controller.Move (horizontalMove, crouch, jump);
			jump = false;
		}
	}

	public override void OnSwitchTo() {
		active = true;
	}

	public override void OnSwitchFrom() { 
		active = false;
	}
}
