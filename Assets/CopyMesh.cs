using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMesh : MonoBehaviour {

	public MeshFilter myMeshFilter;
	public MeshCollider myCollider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myCollider.sharedMesh = myMeshFilter.mesh;
	}

	void Awake() {

	}
}
