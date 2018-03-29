using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    Scene scene;
    public bool cursorVisible = false;

    // Use this for initialization
    void Start()
    {
        
        // Locks cursor in center of the screen and makes it invisible.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = cursorVisible;

        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(scene.name);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}