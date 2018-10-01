using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour {

	public Collider2D Inside_Trigger;
	public Transform Vehicle;
	public string Rider_Tag;
	public Transform Intirior;
	public Transform exit_spawn;
	public Camera Player_Cam;
	public Camera Extirior_Cam;

	ContactFilter2D filter;

	// Update is called once per frame
	void Update () {
		Collider2D[] cols = new Collider2D[20];
		Inside_Trigger.OverlapCollider (filter, cols);

		foreach (Collider2D c in cols) {
			if( c != null) {
				if(c.tag == Rider_Tag) {
					Transform t = c.GetComponent<Transform>();
					Intirior.SendMessage("enter", t);
				}
			}
		}
	}

	void exit(Transform t) {

		Player_Cam.enabled = true;
		//Extirior_Cam.enabled = false;
		Extirior_Cam.SendMessage ("enable", false);
		t.position = exit_spawn.position;
		return;
	}
}
