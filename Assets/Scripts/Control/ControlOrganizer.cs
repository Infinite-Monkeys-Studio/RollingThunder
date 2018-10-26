using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOrganizer : MonoBehaviour {

	[SerializeField]Controller[] controllerList;
	[SerializeField]int activeControllerId = 0;

	// Use this for initialization
	void Start () {
		controllerList [activeControllerId].OnSwitchTo ();
	}

	public void switchTo(string newControl) {
		for (int i = 0; i < controllerList.Length; i++) {
			if(controllerList[i].name == newControl) {
				switchTo(i);
				return;
			}
		}
		throw new UnityException ("No such Controller: \"" + newControl + "\"");
	}

	void switchTo(int newControllerId) {
		Debug.Log ("switch to " + newControllerId);
		controllerList [activeControllerId].OnSwitchFrom ();
		
		controllerList [newControllerId].OnSwitchTo ();

		activeControllerId = newControllerId;
	}
}
