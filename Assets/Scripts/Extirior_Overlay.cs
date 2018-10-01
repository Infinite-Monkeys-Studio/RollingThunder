using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extirior_Overlay : MonoBehaviour {

	public RenderTexture outside;
	public Texture sky;
	public bool render_background;
	public CameraClearFlags inside_clearflags;
	public CameraClearFlags outside_clearflags;

	private Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void Update () {
		if (render_background) {
			cam.clearFlags = inside_clearflags;
		} else {
			cam.clearFlags = outside_clearflags;
		}
	}

	void OnGUI() {
		if (render_background) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), sky);

			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), outside);

			cam.Render ();
		}
	}
}
