using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour {

	public Canvas MainMenu;
	public Canvas Options;
	public Canvas Loading;
	public Slider loadingBar;

	public void OnPlay() {
		Debug.Log ("Play");
		Loading.enabled = true;
		MainMenu.enabled = false;
		StartCoroutine(LoadAsync ("TravelScene"));
	}

	public void OnOptions() {
		MainMenu.enabled = false;
		Options.enabled = true;
	}

	public void OnExit() {
		Debug.Log ("Exit");
		Application.Quit ();
	}

	public void OnOptionsBack() {
		MainMenu.enabled = true;
		Options.enabled = false;
	}

	public void OnOptionsVolume(float Value) {
		Debug.Log ("volume change" + Value);
	}

	IEnumerator LoadAsync(string sceneName) {
		AsyncOperation loadOperation = SceneManager.LoadSceneAsync (sceneName);
		
		while (!loadOperation.isDone) {
			float progress = Mathf.Clamp01(loadOperation.progress);
			Debug.Log("loading: " + progress);
			loadingBar.value = progress;
			yield return null;
		}
	}
}
