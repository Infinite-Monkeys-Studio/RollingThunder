using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraOrganizer : MonoBehaviour {

	[System.Serializable]
	public class CameraView {
		public string name;
		public Camera[] CameraList;
	}

	[SerializeField] private CameraView[] ViewList;
	[SerializeField] private int activeViewId = 0;

	[System.Serializable]
	public class IntEvent : UnityEvent <int> {}
	public IntEvent OnSwitchEvent;

	void Start() {
		OnSwitchEvent = new IntEvent ();

		alloff ();
		switchTo (activeViewId);
	}

	public bool switchTo(string viewName) {
		for (int i = 0; i < ViewList.Length; i++) {
			CameraView view = ViewList[i];
			if (view.name == viewName) 
				return switchTo (i);
		}

		throw new UnityException ("No CameraView with name: \"" + viewName + "\"");
	}

	public bool switchTo(int newViewId) {
		CameraView oldView = ViewList [activeViewId];
		CameraView newView = ViewList [newViewId];

		//disable all old cameras
		foreach (Camera cam in oldView.CameraList) {
			cam.enabled = false;
		}

		//enable new cameras
		foreach (Camera cam in newView.CameraList) {
			cam.enabled = true;
		}

		activeViewId = newViewId;
		OnSwitchEvent.Invoke (activeViewId);
		return true;
	}

	void alloff() {
		foreach (CameraView view in ViewList) {
			foreach(Camera cam in view.CameraList) {
				cam.enabled = false;
			}
		}
	}
}
