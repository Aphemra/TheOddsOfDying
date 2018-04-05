using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPuzzle : MonoBehaviour
{

    public GameObject[] levers;
    public bool doorIsOpen = false;

    private InteractionState lever0, lever1, lever2, lever3, lever4, lever5;


    private void Awake()
    {
        lever0 = levers[0].GetComponent<InteractionState>();
        lever1 = levers[1].GetComponent<InteractionState>();
        lever2 = levers[2].GetComponent<InteractionState>();
        lever3 = levers[3].GetComponent<InteractionState>();
        lever4 = levers[4].GetComponent<InteractionState>();
        lever5 = levers[5].GetComponent<InteractionState>();
    }

    // Update is called once per frame
    void Update()
    {

        // Solution: 100110

        if (lever0.getIsActive() && !lever1.getIsActive() && !lever2.getIsActive() && lever3.getIsActive() && lever4.getIsActive() && !lever5.getIsActive() && !doorIsOpen)
        {
            doorIsOpen = true;
        }

        // If solution is invalidated, door closes again. (Opposite of solution above): 011001
        if ((!lever0.getIsActive() || lever1.getIsActive() || lever2.getIsActive() || !lever3.getIsActive() || !lever4.getIsActive() || lever5.getIsActive()) && doorIsOpen)
        {
            doorIsOpen = false;
        }
    }
}