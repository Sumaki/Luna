using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform destination;

    private void OnCollisionEnter(Collision collision)
    {
        // change for tag
        if(collision.transform.tag == "Player")
        {
            Debug.Log("TP'd");
            collision.transform.gameObject.GetComponent<CharacterController>().enabled = false;
            collision.transform.gameObject.transform.position = destination.position;
            collision.transform.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

    

    
}
