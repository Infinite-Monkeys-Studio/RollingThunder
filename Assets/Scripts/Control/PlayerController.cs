using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public CharacterController2D controller;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	void Update() {
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

	void FixedUpdate() {
		controller.Move (horizontalMove, crouch, jump);
		jump = false;
	}
}
