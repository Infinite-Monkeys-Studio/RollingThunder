using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Controller : MonoBehaviour {

	public ControlOrganizer organizer;
	new public string name;
	public bool active;

	public abstract void OnSwitchTo();
	public abstract void OnSwitchFrom();

}

