using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Controller : MonoBehaviour {

	public Transform Exit_Position;

	Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnter(Transform player, Transform lock_Position) {
		player.position = lock_Position.position;
		
		//Extirior_Cam.SendMessage ("enable", true);
	}
}
