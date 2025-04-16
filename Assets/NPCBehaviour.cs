using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

public class NPCBehaviour : MonoBehaviour
{
    private bool _playerIsInRange = false;

    public GameObject DialogWindow;
    public TMP_Text DialogText;
    public Animator PortraitAnimator;
    public string[] NPCDialog;
    public float interactionDistance = 3f;
    private int TextID = 0;

    // Start is called before the first frame update

    void Start()
    {
        DialogText.text = NPCDialog[0];
        DialogWindow.SetActive(false);
    }

    // Update is called once per frame

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(gameObject.transform.position, Camera.main.transform.position) < interactionDistance)
        {
            if (DialogWindow.activeInHierarchy == false)
            {
                DialogWindow.SetActive(true);
                TextID = 0;
            }
            else
            {
                TextID++;
            }

            if (TextID == NPCDialog.Length)
            {
                DialogWindow.SetActive(false);
            }
            else
            {
                PlayTalkingAnimation();
                DialogText.text = NPCDialog[TextID];
            }
        }

        if (DialogWindow.activeInHierarchy == true)
        {
            if (Vector3.Distance(gameObject.transform.position, Camera.main.transform.position) > interactionDistance)
            {
                DialogWindow.SetActive(false);
            }
        }
    }
    
    private void StartDialog()
    {
        TextID = 0;
        DialogWindow.SetActive(true);
        AdvanceText();
    }

    private void AdvanceText()
    {
        DialogText.text = NPCDialog[0];
    }

    private void EndDialog()
    {
        DialogWindow.SetActive(false);
    }

    private void PlayTalkingAnimation()
    {
        PortraitAnimator.SetBool("isTalking", true);
        Invoke("StopTalkingAnimation", 1f);
    }

    private void StopTalkingAnimation()
    {
        PortraitAnimator.SetBool("isTalking", false);
    }
}
