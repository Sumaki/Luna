using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Player Properties
    CharacterController cc;

    public bool grab = false;
    public bool parented = false;


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

    // Set true in inspector to see certain values.
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

        

        // If the user grabs, apply movement to its forward, else apply normal movement.
        if (!grab && !parented)
        {
            // Set move variable
            move = new Vector3(horizontalMovement, 0, verticalMovement);           
        }
        else if (grab && parented)
        {
            // Rework later if needed
            Vector3 objFwd = Vector3.zero;
            if (verticalMovement != 0 && horizontalMovement == 0)
            {
                move = new Vector3(0, 0, verticalMovement);
            }
            else if (verticalMovement == 0 && horizontalMovement != 0)
            {
                move = new Vector3(horizontalMovement, 0, 0);
            }
            // Set move variable for pushing
            //move = new Vector3(0,0,verticalMovement);     
            if(verticalMovement == 0 && horizontalMovement == 0)
                move = objFwd;
        } 

        // Rotation check
        if (move != Vector3.zero && !grab && !parented)
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
        // Input check to jump + sets variable for the jump animation
        if (Input.GetButtonDown("Jump") && groundedPlayer && !grab)
        {
            
            PlayerAnimatorController.playerState = PlayerAnimatorController.State.jump;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        if (Input.GetKey(KeyCode.E) && PlayerDetections.grabInRange)
        {           
                PlayerAnimatorController.playerState = PlayerAnimatorController.State.interact;
                grab = true;         
        }
        else if (Input.GetKeyUp(KeyCode.E) && PlayerDetections.grabInRange)
        {
            horizontalMovement = 0;
            verticalMovement = 0;
            grab = false;
        }
        
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");


        // The following two if statements sets the animation for the character via a animator controller

        if (verticalMovement == 0 && horizontalMovement == 0 && groundedPlayer)
        {
            PlayerAnimatorController.playerState = PlayerAnimatorController.State.idle;           
        }

        if ((verticalMovement !=0 || horizontalMovement != 0) && groundedPlayer)
        {
            PlayerAnimatorController.playerState = PlayerAnimatorController.State.walk;
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
        //Debug.Log("Movement: " + move);
        Debug.Log("PlayerState: " + PlayerAnimatorController.playerState);
            if (!groundedPlayer)
                Debug.Log("In Air");
            if (verticalMovement == 0 && horizontalMovement == 0)
                Debug.Log("Idle");         
            
    }

    /// <summary>
    /// Hit detections via Character Controller
    /// </summary>
    /// <param name="hit"> What the character controller hits </param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       
    }
   
}
