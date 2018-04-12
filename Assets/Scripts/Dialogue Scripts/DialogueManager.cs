﻿//This script must be included for dialogue to work

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText; //NPC Name
    public Text dialogueText; //Dialogue displayed
    public Animator animator; //Reference to animation for hiding and displaying dialogue box
    public InteractionState interactState;
    public DialogueTrigger midDialogue;
    private Queue<string> lines;

	// Use this for initialization
	void Start () {
        lines = new Queue<string>();
        animator.SetBool("IsOpen", false);
	}

    private void Update()
    {
        
    }

    public void BeginDialogue (Dialogue dialogue, string trigger)
    {
        animator.SetBool("isOpen", true);

        Debug.Log("Dialogue with " + dialogue.name);
        nameText.text = dialogue.name;
        lines.Clear();
        foreach(string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Time.timeScale = 0;

        DisplayNextLine(trigger);
    }

    public void DisplayNextLine(string trigger)
    {
        if(lines.Count == 0)
        {
            EndDialogue(trigger);
            return;
        }

        string line = lines.Dequeue();
        dialogueText.text = line; //Remove comment to make dialogue display immediately instead of scrolling
        //StopAllCoroutines(); //Comment out this line to disable scrolling text
        //StartCoroutine(WriteLine(line)); //Comment out this line to disable scrolling text
        //Debug.Log(line); //Remove comment to log all dialogue lines in debug console
    }

    //Comment out WriteLine to disable scrolling text
    /*IEnumerator WriteLine (string line)
    {
        dialogueText.text = "";
        foreach(char character in line.ToCharArray())
        {
            dialogueText.text += character;
            yield return null;
        }
    }*/

    public void EndDialogue(string trigger)
    {
        animator.SetBool("isOpen", false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Time.timeScale = 1;
        //interactState.setIsActive(false);
        Debug.Log("End dialogue");
    }
	
}