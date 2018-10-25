using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageItemLabel : MonoBehaviour {

	public StorageControl control;
	public ResourceType type;

	[SerializeField]
	private Text Label;
	[SerializeField]
	private Text Value;

	public void Start() {
		Label.text = type.ToString ();
	}

	public void Update() {
		Value.text = control.GetStoredResourcesOfType (type).ToString ();
	}
}
