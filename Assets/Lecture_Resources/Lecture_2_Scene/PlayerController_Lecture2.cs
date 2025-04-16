using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController_Lecture2 : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveDirection;
    public float speed;
    public float rotateSpeed;
    public float fallSpeed;
    private float yMovement;
    public float jumpHeight;
    
    
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded == true)
        {
            yMovement = Mathf.Sqrt(jumpHeight * 2f * fallSpeed);
            //positive value because I multiply with Vector3.up in line 62
        }
        else if (characterController.isGrounded == true)
        {
            yMovement = -0.5f;
            //negative because the gravity should move the player down (negative value * vector3.up = down)
        }
        else
        {
            yMovement += -fallSpeed * Time.deltaTime;
            //negative because the gravity should move the player down (negative value * vector3.up = down)
        }
        
        moveDirection = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = -gameObject.transform.forward;
            //negative forward vector = backwards
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
            //negative angle value to rotate left
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            //positive angle value to rotate right
        }

        moveDirection = moveDirection.normalized;
        
        characterController.Move(moveDirection * speed * Time.deltaTime);//move in direction (forward/backwards)
        characterController.Move(Vector3.up * yMovement * Time.deltaTime);//apply gravity
    }
}
