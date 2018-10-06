using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Controller : Controller {

	public Transform ExitPosition;
	public Transform UsingPosition;


	Transform player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Interact")) {
			//organizer.switchTo(player.GetComponent<Controller>().name);
		}
	}

	public override void OnSwitchTo() {
		player.position = UsingPosition.position;
		player.SetParent (transform);
		active = true;
	}

	public override void OnSwitchFrom() {
		player.position = ExitPosition.position;
		active = false;
	}
}
