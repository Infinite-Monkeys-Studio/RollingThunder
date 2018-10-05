using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour {

	[System.Serializable]
	public class ColliderEvent : UnityEvent <Collider2D> {}
	public ColliderEvent colliderEvent;

	void OnTriggerEnter2D(Collider2D other) {
		colliderEvent.Invoke (other);
	}
}
