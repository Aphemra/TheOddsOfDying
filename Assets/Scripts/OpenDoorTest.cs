using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoorTest : MonoBehaviour {

    public GameObject[] buttons;

    public float translateValue;

    // Set solution text values
    private void Start()
    {
        buttons[0].GetComponentInChildren<Text>().text = "Activate";
        buttons[1].GetComponentInChildren<Text>().text = "Don't Activate";
        buttons[2].GetComponentInChildren<Text>().text = "Activate";
        buttons[3].GetComponentInChildren<Text>().text = "Activate";
    }

    // Update is called once per frame
    void Update () {

        translateValue = transform.position.x;

        // Checks to make sure correct solution is made (1011 in this case)
        // If correct solution, door opens

        if (buttons[0].GetComponent<InteractionState>().getIsActive() && !buttons[1].GetComponent<InteractionState>().getIsActive() && buttons[2].GetComponent<InteractionState>().getIsActive() && buttons[3].GetComponent<InteractionState>().getIsActive() && translateValue < 29.0f)
        {
            transform.Translate(0.03f, 0, 0);
        }

        // If solution is invalidated, door closes again.
        if (!buttons[0].GetComponent<InteractionState>().getIsActive() || buttons[1].GetComponent<InteractionState>().getIsActive() || !buttons[2].GetComponent<InteractionState>().getIsActive() || !buttons[3].GetComponent<InteractionState>().getIsActive())
        {
            if (translateValue > 25.0f)
            {
                transform.Translate(-0.03f, 0, 0);
            }
        }
    }
}
