using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ButtonBehavior_Lecture2 : MonoBehaviour
{

    public Material mActive;
    public Material mInactive;
    private MeshRenderer meshRenderer; //or public, and assign it in the inspector
    private bool _switchState;
    public float maxDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(gameObject.transform.position, Camera.main.transform.position) < maxDistance)
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
    }
}
