using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Inside : MonoBehaviour {

	public Transform extirior;
	public Transform spawn;
	public Collider2D exit;
	public string Rider_tag;
	public Camera Player_Cam;
	public Camera Extirior_Cam;

	ContactFilter2D filter;

	// Update is called once per frame
	void Update () {
		Collider2D[] cols = new Collider2D[20];
		exit.OverlapCollider (filter, cols);
		
		foreach (Collider2D c in cols) {
			if( c != null) {
				if(c.tag == Rider_tag) {
					Transform t = c.GetComponent<Transform>();
					extirior.SendMessage("exit", t);
				}
			}
		}
	}

	void enter(Transform t) {
		Player_Cam.enabled = false;
		//Extirior_Cam.enabled = true;
		Extirior_Cam.SendMessage ("enable", true);
		t.position = spawn.position;
	}
}
