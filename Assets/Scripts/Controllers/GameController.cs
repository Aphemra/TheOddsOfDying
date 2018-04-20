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
    AudioManager am;
    float pitchModifier = 0.5f;

    // Use this for initialization
    void Start()
    {
        fader = FindObjectOfType<SceneFader>();

        // Locks cursor in center of the screen and makes it invisible.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = cursorVisible;

        scene = SceneManager.GetActiveScene();

        am = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if block handling opening pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = !cursorVisible;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

        // Disable reticule if over player Object
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.name == player.name)
                reticulePanel.SetActive(false);
            else if (hit.collider.name != player.name)
                reticulePanel.SetActive(true);
        }

        #region MovementChecking

        // Check to see if character is walking, playing audio appropriately
        if (Input.GetKeyDown(KeyCode.W))
        {
            WalkingAudio(true);
        }
        else if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            WalkingAudio(false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            WalkingAudio(true);
        }
        else if (Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            WalkingAudio(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            WalkingAudio(true);
        }
        else if (Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
        {
            WalkingAudio(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            WalkingAudio(true);
        }
        else if (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            WalkingAudio(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            am.AlterAudio("Footsteps Walking", pitchModifier, true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            am.AlterAudio("Footsteps Walking", pitchModifier, false);
        }

        #endregion

    }

    void WalkingAudio(bool isWalking)
    {
        if (isWalking)
        {
            am.AlterAudio("Footsteps Walking", "Play");
        }

        if (!isWalking)
        {
            am.AlterAudio("Footsteps Walking", "Stop");
        }
    }
}