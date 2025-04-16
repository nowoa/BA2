using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior_Lecture2 : MonoBehaviour
{
    private Animator doorAnimator;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        //be aware that the animator component needs to be on the same object in the inspector as this script for this to work, otherwise assign it publicly
    }

    public void ToggleDoor()
    {
        doorAnimator.SetTrigger("ToggleDoor");
        //you need to have a trigger in the animator called ToggleDoor
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ToggleDoor();
        }
    }
}
