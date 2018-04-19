using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    Scene scene;
    public GameObject player;
    public GameObject reticulePanel;
    public GameObject pauseMenu;//variable for pausemenu
    public bool cursorVisible = false;
    
    Ray ray;
    RaycastHit hit;
    SceneFader fader;

    // Use this for initialization
    void Start()
    {
        fader = FindObjectOfType<SceneFader>();

        // Locks cursor in center of the screen and makes it invisible.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = cursorVisible;

        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        //if (fader.isRunning == false && pauseMenu.activeSelf == false)
        //{
        //    Time.timeScale = 1f;
        //}
        //else
        //{
        //    Time.timeScale = 0f;
        //}

        //if block handling opening pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;//unlock cursor
            Cursor.visible = !cursorVisible;//make cursor visible
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);//set pausemenu canvas to active
        }

        /*if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.Locked;//unlock cursor
            Cursor.visible = !cursorVisible;//make cursor visible
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);//set pausemenu canvas to active
        }*/

        // Disable reticule if over player Object
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.name == player.name)
                reticulePanel.SetActive(false);
            else if (hit.collider.name != player.name)
                reticulePanel.SetActive(true);
        }
    }
}