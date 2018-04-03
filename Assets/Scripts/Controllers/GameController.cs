using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    Scene scene;
    public GameObject player;
    public GameObject reticulePanel;
    public bool cursorVisible = false;
    
    Ray ray;
    RaycastHit hit;

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

        // Disable reticule if over player Object
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);

            if (hit.collider.name == player.name)
                reticulePanel.SetActive(false);
            else if (hit.collider.name != player.name)
                reticulePanel.SetActive(true);
        }
    }
}