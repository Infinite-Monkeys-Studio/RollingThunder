using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAwayView : MonoBehaviour {

	public RenderTexture inside;
	public float offset_X;
	public float offset_Y;
	public float width;
	public float height;

	void drawCutAway() {
		GUI.DrawTexture (new Rect (offset_X, offset_Y, width, height), inside);
	}
}
