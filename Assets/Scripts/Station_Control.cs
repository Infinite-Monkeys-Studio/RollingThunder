using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station_Control : MonoBehaviour {

	public Collider2D Interactable_Area;
	public string Player_Tag;
	public SpriteRenderer Interactable_Indicator;
	public bool Enter_Station;
	public Transform Lock_Posistion;
	public Transform Controller;

	bool interacting = false;
	bool inArea = false;
	ContactFilter2D filter;
	Transform player;

	// Use this for initialization
	void Start () {
		filter = new ContactFilter2D ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Interact")) {
			interacting = true;
		}

		if (Input.GetButtonUp ("Interact")) {
			interacting = false;
		}

		Collider2D[] objs = new Collider2D[10];
		Interactable_Area.OverlapCollider (filter, objs);
		bool change = false;
		foreach (Collider2D col in objs) {
			if(col != null && col.tag == Player_Tag) {
				player = col.transform;
				inArea = true;
				change = true;
			}
		}

		if (!change) {
			inArea = false;
		}

		if (inArea) {
			Interactable_Indicator.enabled = true;
		} else {
			Interactable_Indicator.enabled = false;
		}

		if (inArea && interacting) {
			Interactable_Indicator.transform.Rotate (0, 0, 10);
			if(Enter_Station) {
				//Controller.SendMessage(("OnEnter", player, Lock_Posistion);
			}
		} else {
			Interactable_Indicator.transform.rotation = new Quaternion(0, 0, 0, 0);
		}
	}
}
