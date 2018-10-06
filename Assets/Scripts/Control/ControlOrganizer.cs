using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOrganizer : MonoBehaviour {
	/*
	 * controllerlist
	 * 
	 * 
	 */

	//[SerializeField]IController[] controllerList;
	[SerializeField]Controller[] controllerList;
	[SerializeField]int activeControllerId = 0;

	// Use this for initialization
	void Start () {
		controllerList [activeControllerId].OnSwitchTo ();
	}

	/*public IController getActiveController() {
		return controllerList [activeControllerId];
	}*/

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
		controllerList [activeControllerId].OnSwitchFrom ();
		
		controllerList [newControllerId].OnSwitchTo ();

		activeControllerId = newControllerId;
	}
}
