using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour {

	[System.Serializable]
	public class ColliderEvent : UnityEvent <Collider2D> {}
	[System.Serializable]
	public class DoubleColliderEvent : UnityEvent <Collider2D, Collider2D> {}
	public ColliderEvent colliderEvent;
	public DoubleColliderEvent colliderEnterEvent;
	public DoubleColliderEvent colliderExitEvent;



	void OnTriggerEnter2D(Collider2D other) {
		colliderEvent.Invoke (other);
		colliderEnterEvent.Invoke (other, GetComponent<Collider2D>());
	}

	void OnTriggerExit2D(Collider2D other) {
		colliderExitEvent.Invoke (other, GetComponent<Collider2D>());
	}
}
