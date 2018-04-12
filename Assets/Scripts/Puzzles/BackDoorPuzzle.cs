using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackDoorPuzzle : MonoBehaviour
{

    public GameObject[] levers;
    public bool doorIsOpen = false;

    private InteractionState lever0;


    private void Awake()
    {
        lever0 = levers[0].GetComponent<InteractionState>();
    }

    // Update is called once per frame
    void Update()
    {

        // Solution: 100110

        if (lever0.getIsActive())
        {
            doorIsOpen = true;
        }

        // If solution is invalidated, door closes again. (Opposite of solution above): 011001
        if (!lever0.getIsActive() && doorIsOpen)
        {
            doorIsOpen = false;
        }
    }
}