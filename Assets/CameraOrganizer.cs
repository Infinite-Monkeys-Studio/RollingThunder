using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraOrganizer : MonoBehaviour {
	
	[SerializeField] private Camera[] Cameras;
	[Range(0, Cameras.Length-1)][SerializeField] private int activeCamera = 0;

	[System.Serializable]
	public class IntEvent : UnityEvent <int> {}
	public IntEvent OnSwitchEvent;

	void Start() {
		OnSwitchEvent = new IntEvent ();
	}

	public bool switchTo(int cameraId) {
		if (cameraId == activeCamera)
			return false;
		Cameras [activeCamera].enabled = false;
		activeCamera = cameraId;
		Cameras [activeCamera].enabled = true;
		OnSwitchEvent.Invoke (cameraId);
		return true;
	}

	public Camera getCameraById(int id) {
		return Cameras [id];
	}

	public int getIdByCamera(ref Camera cam) {
		for (int id = 0; id < Cameras.Length; id++) {
			Camera c = Cameras[id];
			if(c == cam) {
				return id;
			}
		}
		return -1;
	}
	

}
