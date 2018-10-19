using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour {

	public Transform GroundObject;
	public int NumberOfDups;
	public Transform Player;
	public float width;

	private float Y_pos;
	private GameObject[] gs;

	// Use this for initialization
	void Start () {
		gs = new GameObject[NumberOfDups];
		Y_pos = transform.position.y;

		for(int i = 0; i < gs.Length;i++) {
			float x = get_x(i);

			Transform clone = Instantiate(GroundObject, transform);
			clone.position = new Vector3(x, Y_pos, 0);
		}
	}
	
	// Update is called once per frame
	/*void Update () {
		for(int i = 0; i < transform.childCount; i++) {
			Transform t = transform.GetChild(i);
			if(t.position.x < get_x(0) || t.position.x > get_x(NumberOfDups)){
				Destroy(t);
			}
		}


	}*/

	float get_x(int i) {
		return i * width - Mathf.Floor(NumberOfDups/2) * width;
	}

}
