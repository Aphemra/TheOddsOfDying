using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //Takes current scene index and adds 1 to it.
    //Since this is for the main menu, the main menu
    //has an index of 0, and the first scene of the
    //game will have an index of 1
	public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Function to quit the application from main menu
    public void QuitGame ()
    {
        //application won't close in editor
        //this code lets us know function works
        Debug.Log("Quit");

        Application.Quit();//closes application
    }


    //just some code to test if clicking the button works
    public void ClickTest ()
    {
        Debug.Log("clicked");
    }
}
