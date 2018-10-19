using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTool : Tool {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	public override void use() {
		Vector3 mousePosistion = Input.mousePosition;
		mousePosistion = Camera.main.ScreenToWorldPoint(mousePosistion);
		Vector2 rayStart = new Vector2 (mousePosistion.x, mousePosistion.y);

		RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.zero, 0f);
		if (hit.collider != null) {
			Debug.Log (hit.transform.gameObject.name);
		}

	}
}
