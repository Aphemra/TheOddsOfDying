using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3ExitTrigger : MonoBehaviour {

    SceneFader fader;

    private void Awake()
    {
        fader = FindObjectOfType<SceneFader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        fader.FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
