using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Player Properties
    CharacterController cc;

    private float verticalMovement;
    private float horizontalMovement;
    private Vector3 playerVelocity;
    private Vector3 move;

    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private float jumpHeight = 0.5f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private bool groundedPlayer;
    [SerializeField]
    private float pullValue;
    [SerializeField]
    private float pushValue;
 
    #endregion

    public bool debug;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        move = Vector3.zero;
    }

    void Update()
    {
        if (debug)
            DebuggerCheck();

        // check grounded via character controller
        groundedPlayer = cc.isGrounded;       
        CheckGrounded();
        UserInput();

        // Set move variable
        move = new Vector3(horizontalMovement, 0, verticalMovement);

        // Rotation check
        if (move != Vector3.zero)
        {
           transform.rotation = Quaternion.LookRotation(move);
        }

        // Initial movement         
        cc.Move(move * Time.deltaTime * speed);

        // Apply gravity to take into factor after
        playerVelocity.y += gravityValue * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);       
    }

    /// <summary>
    /// Read player's input then set variables to apply for movement.
    /// </summary>
    void UserInput()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");


        // The following two if statements sets the animation for the character via a animator controller

        if (verticalMovement == 0 && horizontalMovement == 0)
        {
            // idle = true
            // walk/run = false            
        }

        if (verticalMovement > 0 || verticalMovement < 0 || horizontalMovement > 0 || horizontalMovement < 0)
        {
            // walk/run = true
            // idle = false   
        }
       
        // Input check to jump + sets variable for the jump animation
        if(Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // jump = true
            // run = false
            
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

       
    }
    /// <summary>
    /// Check if the player is grounded then apply its velocity to 0.
    /// </summary>
    void CheckGrounded()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            // jump = false <- set for animation for transition
            playerVelocity.y = 0f;
        }
    }

    /// <summary>
    /// Enables debugger for player variables.
    /// </summary>
    void DebuggerCheck()
    {             
            Debug.Log("Movement: " + move);
            if (!groundedPlayer)
                Debug.Log("In Air");
            if (verticalMovement == 0 && horizontalMovement == 0)
                Debug.Log("Idle");            
    }
}
