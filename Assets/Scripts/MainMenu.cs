using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuCanvas;
    public GameObject helpMenuCanvas;

    // Loads next scene (should be first level)
	public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Switches between MainMenu and HelpMenu
    public void SwitchMenu_MainHelp()
    {
        mainMenuCanvas.SetActive(!mainMenuCanvas.activeSelf);
        helpMenuCanvas.SetActive(!helpMenuCanvas.activeSelf);
    }

    // Quits game
    public void Exit()
    {
        Debug.Log("Quit"); // For in editor only

        Application.Quit(); // Closes application
    }
}
