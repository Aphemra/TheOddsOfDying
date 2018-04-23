using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceGateAnimController : MonoBehaviour
{

    Animator gateAnim;
    bool isOpen = false;
    public bool puzzleBeat = false;

    // Use this for initialization
    void Start()
    {
        gateAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleBeat && !isOpen)
        {
            gateAnim.Play("OpenGate");
            GetComponent<AudioSource>().Play();
            isOpen = true;
        }
    }
}