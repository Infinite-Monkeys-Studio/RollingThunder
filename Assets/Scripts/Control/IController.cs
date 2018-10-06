using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController {

	void OnSwitchTo();
	void OnSwitchFrom();

	string getName();
	bool enabled();
	bool enabled(bool enabled);

}
