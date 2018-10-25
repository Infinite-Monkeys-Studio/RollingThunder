using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Tool : MonoBehaviour {

	new public string name;
	public bool active;

	[SerializeField]
	private bool rotateTool = true;
	
	// Update is called once per frame
	protected virtual void Update () {
		if (active && rotateTool) {

			Vector3 mousePosistion = Input.mousePosition;
			mousePosistion = Camera.main.ScreenToWorldPoint(mousePosistion);
			
			Vector2 direction = new Vector2(mousePosistion.x - transform.position.x, mousePosistion.y - transform.position.y);

			direction *= Mathf.Sign(transform.parent.parent.localScale.x);
			transform.right = direction;
		}
	}

	public abstract void use();

	public virtual void setActive() {
		active = true;
		GetComponent<SpriteRenderer> ().enabled = true;
	}

	public virtual void setInactive() {
		active = false;
		GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void setActive(bool act) {
		if (act) {
			setActive ();
		} else {
			setInactive();
		}
	}

}
