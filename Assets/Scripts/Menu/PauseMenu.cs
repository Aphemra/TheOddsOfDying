using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject mainMenuCanvas;
    public GameObject helpMenuCanvas;
    public GameObject pauseMenu;

    private SceneFader fader;

    private void Awake()
    {
        fader = FindObjectOfType<SceneFader>();
    }

    // Resumes game
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;//unlock cursor
        Cursor.visible = false;//make cursor visible
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    // Switches between MainMenu and HelpMenu
    public void SwitchMenu_MainHelp()
    {
        StartCoroutine(SetTimeScale(1, 0));
        if (mainMenuCanvas.GetComponent<GraphicRaycaster>().enabled)
            fader.CrossFadeObjects(mainMenuCanvas, helpMenuCanvas);
        else if (helpMenuCanvas.GetComponent<GraphicRaycaster>().enabled)
            fader.CrossFadeObjects(helpMenuCanvas, mainMenuCanvas);
        StartCoroutine(SetTimeScale(0, 1));
    }

    // Quits game
    public void Exit()
    {
        Debug.Log("Quit"); // For in editor only

        Application.Quit(); // Closes application
    }

    public void ToMainMenu()
    {
        fader.FadeToScene(0);
    }

    IEnumerator SetTimeScale(float scale, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = scale;
    }
}