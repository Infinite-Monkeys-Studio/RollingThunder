using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

	public CharacterController2D controller;
	public float MovementSpeed = 10f;
	public Animator animator;

	float horizontalMove = 0f;
	bool jump = false;


	void Update() {
		if (active) {
			horizontalMove = Input.GetAxisRaw ("Horizontal");
			animator.SetFloat("Speed", Mathf.Abs (horizontalMove));
	
			if (Input.GetButtonDown ("Jump")) {
				jump = true;
				animator.SetTrigger("Jump");
			}
		}
	}

	void FixedUpdate() {
		if (active) {
			controller.Move (horizontalMove * MovementSpeed, jump);
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
