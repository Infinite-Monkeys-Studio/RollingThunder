using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour {

	[SerializeField]
	[Tooltip("Set to -1 for no active tool")]
	private int activeTool;

	[SerializeField]
	private Tool[] tools;


	// Use this for initialization
	void Start () {
		foreach (Tool t in tools) {
			t.setInactive();
		}
		if (activeTool > -1) {
			tools [activeTool].setActive ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			if(activeTool >= 0) {
				tools[activeTool].use();
			}
		}

		if(Input.GetKeyDown("1")) {
			switchTo(0);
		}
	}

	public void setNoTool() {
		switchTo (-1);
	}

	public void switchTo(string toolName) {
		switchTo (findToolByName (toolName));
	}

	private int findToolByName(string toolName) {
		for(int i = 0; i < tools.Length; i++) {
			if(tools[i].name == toolName) {
				return i;
			}
		}
		throw new UnityException (string.Format ("No Tool with name: {0}", toolName)); 
	}

	private void switchTo(int t) {
		if(activeTool > -1) tools [activeTool].setActive (false);
		activeTool = t;
		if(activeTool > -1)
			tools [activeTool].setActive ();
	}

}
