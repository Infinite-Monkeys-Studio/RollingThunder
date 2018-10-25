using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Control : Controller {

	public float max_speed;

	float throttle;

	// Update is called once per frame
	public override void Update () {
		base.Update ();
		if (active) {
			throttle = Input.GetAxisRaw ("Horizontal");
		} else {
			throttle = 0;
		}
	}

	void FixedUpdate() {
		foreach (WheelJoint2D j in GetComponents<WheelJoint2D> ()) {
			JointMotor2D m = j.motor;
			m.motorSpeed = max_speed * throttle * -1f;
			j.motor = m;
		}
	}
}
