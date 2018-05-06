using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Menu : MonoBehaviour {

	void Update () {
		float submitRaw = CrossPlatformInputManager.GetAxisRaw("Submit");
		float cancelRaw = CrossPlatformInputManager.GetAxisRaw("Cancel");

		if (submitRaw == 1) {
			SceneManager.LoadScene(1);
		}

		if (cancelRaw == 1) {
            Application.Quit();
		}
	}
}
