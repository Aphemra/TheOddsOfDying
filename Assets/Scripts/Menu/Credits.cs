using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    SceneFader fader;

	// Use this for initialization
	void Awake () {
        fader = FindObjectOfType<SceneFader>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	public void ReturnToMainMenu()
    {
        fader.FadeToScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
