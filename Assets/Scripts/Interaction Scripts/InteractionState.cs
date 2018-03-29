using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionState : MonoBehaviour {
    
    // Changes based on MovementControlScript
    [SerializeField] private bool isActive = false;

    public void setIsActive (bool state)
    {
        isActive = state;
    }

    public bool getIsActive ()
    {
        return isActive;
    }
}
