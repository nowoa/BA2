using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private float speed;
    public float WalkSpeed;
    public float RunSpeed;
    public float rotateSpeed;
    public float fallSpeed;
    private float yMovement;
    private bool _isGrounded;
    public float jumpHeight;
    public Material m;
    
    private enum PlayerState
    {
        IDLE,
        WALK,
        Running, 
        JUMP,
        DoubleJump
    }

    private PlayerState currentState = PlayerState.IDLE;
    
    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
    }

    private void StateUpdate2()
    {
        switch (currentState)
        {
            case PlayerState.IDLE:
                
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    currentState = PlayerState.WALK;
                }
            
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                    currentState = PlayerState.JUMP;
                }
                
                break;
            
            case PlayerState.WALK:
                
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    currentState = PlayerState.Running;
                }
            
                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
                { //if the player is not pressing W AND not pressing A AND not pressing S AND not pressing D, state = idle
                    currentState = PlayerState.IDLE;
                }
            
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                    currentState = PlayerState.JUMP;
                }

                speed = WalkSpeed;
                GetMoveDirection();
                
                break;
            
            case PlayerState.Running:
                
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    currentState = PlayerState.WALK;
                }
            
                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                { //if the player is not pressing W AND not pressing A AND not pressing S AND not pressing D, state = idle
                    currentState = PlayerState.WALK;
                }
            
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                    currentState = PlayerState.JUMP;
                }
                speed = RunSpeed;
                GetMoveDirection();
                
                break;
            
            case PlayerState.JUMP:
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                    currentState = PlayerState.DoubleJump;
                }

                if (_characterController.isGrounded == true)
                {
                    currentState = PlayerState.IDLE;
                }
                
                GetMoveDirection();
                
                break;
            
            case PlayerState.DoubleJump:
                
                if (_characterController.isGrounded == true)
                {
                    currentState = PlayerState.IDLE;
                }
                
                GetMoveDirection();
                
                break;
        }
    }
    
    private void StateUpdate()
    {
        switch (currentState)
        {
            case PlayerState.IDLE:
                //idle behavior goes here
                break;
            case PlayerState.WALK:
                //walking behavior goes here
                break;
            case PlayerState.JUMP:
                //jumping behavior goes here
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (_characterController.isGrounded == true)
        {
            yMovement = -0.5f;
            m.color = Color.green;
        }
        else
        {
            yMovement += -fallSpeed * Time.deltaTime;
            m.color = Color.red;
        }
        _moveDirection = Vector3.zero;
        
        StateUpdate2();

        _moveDirection = _moveDirection.normalized;
        _characterController.Move(_moveDirection * speed * Time.deltaTime);//move in direction

        _characterController.Move(Vector3.up * yMovement * Time.deltaTime);//apply gravity
        
    }

    private void GetMoveDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _moveDirection = gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveDirection = -gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        yMovement = Mathf.Sqrt(jumpHeight * -2f * -fallSpeed); 
    }
    
    
    
    
    

}
