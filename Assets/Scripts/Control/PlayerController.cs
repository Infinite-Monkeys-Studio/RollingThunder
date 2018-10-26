using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller {

	public CharacterController2D controller;
	public float MovementSpeed = 10f;
	public float ClimbSpeed = 5f;
	public Animator animator;

	float horizontalMove = 0f;
	float verticalMove = 0f;
	bool jump = false;
	bool onLadder = false;
	float baseGravityScale;

	public override void Start() {
		base.Start ();
		baseGravityScale = GetComponent<Rigidbody2D> ().gravityScale;
	}

	public override void Update() {
		if (active) {
			horizontalMove = Input.GetAxisRaw ("Horizontal");
			verticalMove = Input.GetAxisRaw ("Vertical");
			animator.SetFloat("Speed", Mathf.Abs (horizontalMove));
	
			if (Input.GetButtonDown ("Jump")) {
				jump = true;
				animator.SetTrigger("Jump");
			}


		}
	}

	void FixedUpdate() {
		if (active) {
			if(onLadder) {
				controller.Climb(verticalMove * ClimbSpeed, horizontalMove * MovementSpeed);
			} else {
				controller.Move (horizontalMove * MovementSpeed, jump);
			}

			if(horizontalMove < .5f)
				controller.faceMouse();
			jump = false;
			GetComponent<Rigidbody2D>().gravityScale = onLadder ? 0 : baseGravityScale;
		}
	}

	public void onLadderEnter(Collider2D other, Collider2D ladder) {
		if(other.tag == "Player")
			onLadder = true;
	}

	public void onLadderExit(Collider2D other, Collider2D ladder) {
		if(other.tag == "Player")
			onLadder = false;
	}

//	public override void OnSwitchTo() {
//		active = true;
//	}
//
//	public override void OnSwitchFrom() { 
//		active = false;
//	}
}
