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


	protected Transform player;
	private bool interactFlag = false;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	public virtual void Update() {
		if (active && Input.GetButtonUp ("Interact")) {
			interactFlag = true;
		}

		if(active && Input.GetButtonDown("Interact") && interactFlag) {
			organizer.switchTo(player.GetComponent<Controller>().name);
		}
	}

	public virtual void OnSwitchTo() {
		if (EnterableController) {
			player.position = UsingPosition.position;
			GameObject go = player.gameObject;
			go.SetActive (false);
		}

		active = true;
	}

	public virtual void OnSwitchFrom() {
		if (EnterableController) {
			player.position = ExitPosition.position;
			GameObject go = player.gameObject;
			go.SetActive (true);
		}
		interactFlag = false;
		active = false;
	}

}

