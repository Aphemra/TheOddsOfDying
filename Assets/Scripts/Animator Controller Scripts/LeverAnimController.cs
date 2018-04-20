using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionState))]
public class LeverAnimController : MonoBehaviour {

    Animator leverAnim;
    bool isActivated = false;

    // Use this for initialization
    void Start()
    {
        leverAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<InteractionState>().getIsActive() && isActivated == false)
        {
            leverAnim.Play("Activate");
            GetComponent<AudioSource>().Play();
            isActivated = true;
        }
        else if (!GetComponent<InteractionState>().getIsActive() && isActivated == true)
        {
            leverAnim.Play("Deactivate");
            GetComponent<AudioSource>().Play();
            isActivated = false;
        }
    }
}
