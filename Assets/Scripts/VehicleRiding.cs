using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VehicleRiding: MonoBehaviour {

	public CameraOrganizer cameraOrganizer;
	public string Rider_Tag;
	[Space]
	public ColliderTrigger enter_Trigger;
	public Transform enter_spawn;
	public string CameraViewNameEnter;
	[Space]
	public ColliderTrigger ExitTrigger;
	public Transform exit_spawn;
	public string CameraViewNameExit;

	UnityAction<Collider2D> enterAction;
	UnityAction<Collider2D> exitAction;

	void Start() {
		enterAction += enter;
		exitAction += exit;

		enter_Trigger.colliderEvent.AddListener (enterAction);
		ExitTrigger.colliderEvent.AddListener (exitAction);
	}

	public void exit(Collider2D other) {
		if (other.tag == Rider_Tag) {
			Transform t = other.transform;
			cameraOrganizer.switchTo (CameraViewNameExit);
			t.position = exit_spawn.position;
		}
	}

	public void enter(Collider2D other) {
		if (other.tag == Rider_Tag) {
			Transform t = other.transform;
			cameraOrganizer.switchTo (CameraViewNameEnter);
			t.position = enter_spawn.position;
		}
	}
}
