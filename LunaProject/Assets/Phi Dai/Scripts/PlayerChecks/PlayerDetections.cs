using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetections : MonoBehaviour
{
    [SerializeField]
    private float hitDetectionRange = 1f;

    public static bool grabInRange = false;
    public static RaycastHit hit;
    PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        GrabRangeCheck();
    }

    /// <summary>
    /// This method sends a Raycast in a fixed distance to check if it collides with any object and will allow the object to be grabbed
    /// if the object itself has a "PushObj" tag. It will set the grabInRange parameter.
    /// </summary>
    void GrabRangeCheck()
    {

        if (Physics.Raycast(playerInput.cc.transform.position, playerInput.cc.transform.forward, out hit, hitDetectionRange))
        {
            Debug.DrawRay(playerInput.cc.transform.position, playerInput.cc.transform.forward * hitDetectionRange, Color.yellow);
            if (hit.transform.tag == "PushObj")
            {
                Debug.Log("In sight of pushable object");
                grabInRange = true;
                ConfirmInputs(hit.transform.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            grabInRange = false;
        }
    }

    void ConfirmInputs(GameObject hit)
    {
        CheckParent(hit);
    }


    /// <summary>
    /// Checks whatever or not the gameobject contains another object that is parent to it. If it's good we will parent to it.
    /// </summary>
    /// <param name="hit"> What object we are checking </param>
    void CheckParent(GameObject hit)
    {
        // check grab bool variable to confirm the parent
        // add the parent to its object       
        if (playerInput.grab)
        {
            if (hit.transform.parent != transform)
            {
                hit.transform.parent = transform;
                playerInput.parented = true;
                Debug.Log("Parented");
            }
        }
        else if (!playerInput.grab)
        {
            if (hit.transform.parent == transform)
            {
                hit.transform.parent = null;
                playerInput.parented = false;
                Debug.Log("Unparented");
            }
        }
    }
}
