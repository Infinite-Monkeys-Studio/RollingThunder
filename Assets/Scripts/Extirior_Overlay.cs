using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extirior_Overlay : MonoBehaviour {

	public RenderTexture inside;
	public bool render_inside;
	public float offset_X;
	public float offset_Y;
	public float width;
	public float height;


	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		if (render_inside) {
			GUI.DrawTexture (new Rect (offset_X, offset_Y, width, height), inside);
		}
	}
}
