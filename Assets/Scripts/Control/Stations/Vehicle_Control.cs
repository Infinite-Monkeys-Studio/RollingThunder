using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Control : MonoBehaviour {

	public SliderJoint2D throttle;
	public float max_speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (throttle.jointTranslation);
		foreach (WheelJoint2D j in GetComponents<WheelJoint2D> ()) {
			JointMotor2D m = j.motor;
			m.motorSpeed = max_speed * throttle.jointTranslation * -1f;
			j.motor = m;

		}
	}
}
