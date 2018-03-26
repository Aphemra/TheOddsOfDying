using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPuzzle : MonoBehaviour
{

    public GameObject[] levers;
    public bool doorIsOpen = false;

    // Update is called once per frame
    void Update()
    {

        // Checks to make sure correct solution is made (1011 in this case)
        // If correct solution, door opens

        if (levers[3].GetComponent<InteractionState>().getIsActive() && !levers[2].GetComponent<InteractionState>().getIsActive() && levers[1].GetComponent<InteractionState>().getIsActive() && levers[0].GetComponent<InteractionState>().getIsActive() && !doorIsOpen)
        {
            doorIsOpen = true;
        }

        // If solution is invalidated, door closes again.
        if ((!levers[3].GetComponent<InteractionState>().getIsActive() || levers[2].GetComponent<InteractionState>().getIsActive() || !levers[1].GetComponent<InteractionState>().getIsActive() || !levers[0].GetComponent<InteractionState>().getIsActive()) && doorIsOpen)
        {
            doorIsOpen = false;
        }
    }
}