﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceGateAnimController : MonoBehaviour
{

    Animator gateAnim;
    bool isOpen = false;

    // Use this for initialization
    void Start()
    {

        gateAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isOpen)
        {
            gateAnim.Play("OpenGate");
            //GetComponent<AudioSource>().Play();
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.O) && isOpen)
        {
            gateAnim.Play("CloseGate");
            //GetComponent<AudioSource>().pitch -= 0.3f;
            //GetComponent<AudioSource>().Play();
            isOpen = false;
        }
    }
}