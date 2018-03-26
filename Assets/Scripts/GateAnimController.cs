﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimController : MonoBehaviour {

    Animator gateAnim;
    bool isOpen = false;

	// Use this for initialization
	void Start () {

        gateAnim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<DoorPuzzle>().doorIsOpen && !isOpen)
        {
            gateAnim.Play("OpenGate");
            isOpen = true;
        }
        else if (!GetComponent<DoorPuzzle>().doorIsOpen && isOpen)
        {
            gateAnim.Play("CloseGate");
            isOpen = false;
        }
    }
}