using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Controller : MonoBehaviour {

	public ControlOrganizer organizer;
	new public string name;
	public bool active;
	public bool EnterableController;
	public Transform UsingPosition;
	public Transform ExitPosition;

	private float switchTime;

	[SerializeField]
	protected Transform player;

	public virtual void Update() {
		if (Time.time - switchTime > .5f) {
			if (active && Input.GetButtonDown ("Interact")) {
				organizer.switchTo ("Player");
				Debug.Log ("switch calling");
			}
		}
	}

	public virtual void OnSwitchTo() {
		if (EnterableController) {
			player.position = UsingPosition.position;
			GameObject go = player.gameObject;
			go.SetActive (false);
			Debug.Log ("switched to enterable");
		}

		switchTime = Time.time;
		active = true;
		Debug.Log ("switched to");
	}

	public virtual void OnSwitchFrom() {
		if (EnterableController) {
			player.position = ExitPosition.position;
			GameObject go = player.gameObject;
			go.SetActive (true);
			Debug.Log ("switched from enterable");
		}
		active = false;
		Debug.Log ("1");
	}

}

