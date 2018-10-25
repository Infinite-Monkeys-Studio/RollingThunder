using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageControl : MonoBehaviour {

	[System.Serializable]
	private class StorageItem {

		[SerializeField]
		public ResourceType resourceType;
		public int quantity;

		public StorageItem(ResourceType resourceType, int quantity) {
			this.resourceType = resourceType;
			this.quantity = quantity;
		}

		public bool Equals(StorageItem other) {
			if (other == null)
				return false;
			return resourceType.Equals(other.resourceType);
		}
	}

	[SerializeField]
	private List<StorageItem> StoredResources;

	// Use this for initialization
	void Start () {
		//StoredResources = new List<StorageItem> ();
	}



	public void addItem(ResourceType type, int quantity) {
		StorageItem newItem = new StorageItem (type, quantity);
		addItem (newItem);
	}

	private void addItem(StorageItem newItem) {
		int parentIndex = StoredResources.IndexOf (newItem);

		if(parentIndex == -1) { // add a new entry we don't have this type yet
			StoredResources.Add(newItem);
		} else { // merge with exsisting entry
			StoredResources[parentIndex].quantity += newItem.quantity;
		}
	}

	public int GetStoredResourcesOfType(ResourceType type) {
		StorageItem i = StoredResources.Find (x => x.resourceType == type);
		if (i == null) {
			return 0;
		}
		return i.quantity;
	}
}
