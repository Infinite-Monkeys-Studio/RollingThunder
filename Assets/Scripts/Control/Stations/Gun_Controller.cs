using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Controller : Controller {

	public float fireRate;
	public Transform Barrel;
	public GameObject bullet;
	public float bulletSpeed;

	bool shooting = false;
	float fireDelay = 0;

	// Update is called once per frame
	public override void Update () {
		base.Update ();
		if (active) {
			if(Input.GetButtonDown("Fire1")) {
				shooting = true;
			}

			if(Input.GetButtonUp("Fire1")) {
				shooting = false;
			}

			Vector3 mousePosistion = Input.mousePosition;
			mousePosistion = Camera.main.ScreenToWorldPoint(mousePosistion);

			Vector2 direction = new Vector2(mousePosistion.x - transform.position.x, mousePosistion.y - transform.position.y);

			transform.right = direction;
		}
	}

	void FixedUpdate() {
		if (shooting) {
			if (fireDelay > fireRate) {
				fire();
				fireDelay = 0;
			}
		}

		fireDelay += Time.fixedDeltaTime;
	}

	void fire() {
		GameObject b = GameObject.Instantiate (bullet, Barrel.position, Barrel.rotation);
		b.GetComponent<Rigidbody2D>().AddForce(b.transform.up.normalized * bulletSpeed);

	}

	public override void OnSwitchFrom() {
		base.OnSwitchFrom ();
	}
}
