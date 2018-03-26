using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckInteractions : MonoBehaviour {

    public float interactDistance = 2.0f;
    public TextMeshProUGUI interactControls;

    private bool isInteractionAvailable = false;

    private void Start()
    {
        interactControls.enabled = false;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 inFront = transform.TransformDirection(Vector3.forward);

        // Checks if there is an object in front of the player and sets a boolean accordingly
        if (Physics.Raycast(transform.position, inFront, out hit, interactDistance) && hit.transform.tag == "Interactable")
        {
            isInteractionAvailable = true;
            interactControls.enabled = true;
        }
        if (!Physics.Raycast(transform.position, inFront, out hit, interactDistance))
        {
            isInteractionAvailable = false;
            interactControls.enabled = false;
        }

        // Checks whether above boolean is true and the "E" key is pressed down.
        // If both are true, it sets the state of the interactable object as
        // the opposite of it's previous state. (False is true, true if false)
        if (Input.GetButtonDown("Interact") && isInteractionAvailable)
        {
            
            InteractionState state = hit.collider.GetComponent<InteractionState>();
            if (state != null && !state.getIsActive())
            {
                state.setIsActive(true);
                Debug.Log("Interacted With! Set to: " + state.getIsActive());
            }
            else if (state != null && state.getIsActive())
            {
                state.setIsActive(false);
                Debug.Log("Interacted With! Set to: "  + state.getIsActive());
            }
        }
    }
}
