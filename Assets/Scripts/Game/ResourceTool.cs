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
		if (hit.transform != null) {
			Harvestable resObj = hit.transform.GetComponent<Harvestable>();
			if(resObj != null) {
				if(resObj.workable) {
					int result = resObj.work(Time.deltaTime);
					Debug.Log (string.Format("Harvested {0} from {1}", result, resObj.name));
					return;
				} else {
					Debug.Log("harvestable. not workable");
					return;
				}
			}
			Debug.Log("not harvestable");
			return;
		}
		Debug.Log("nothing there");
		return;
	}
}
