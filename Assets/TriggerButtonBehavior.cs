using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerButtonBehavior : MonoBehaviour
{
    public Material mActive;
    public Material mInactive;
    public MeshRenderer meshRenderer;
    private bool playerIsInRange;
    private bool _switchState;
    public UnityEvent onButtonPress;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
            playerIsInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInRange = false;
        }
    }

    private void OnMouseDown()
    {
        if (playerIsInRange == true)
        {
            Switch();
        }
    }
    
    private void Switch()
    {
        _switchState = !_switchState;

        if (_switchState == true)
        {
            meshRenderer.material = mActive;
        }
        else
        {
            meshRenderer.material = mInactive;
        }
        
        onButtonPress.Invoke();
    }
}
