using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Inside : MonoBehaviour {

	public Transform extirior;
	public Transform spawn;
	public Collider2D exit;
	public string Rider_tag;
	
	ContactFilter2D filter;

	// Use this for initialization
	void Start () {
		//filter.layerMask = Can_Ride;
	}
	
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
		t.position = spawn.position;
	}
}
