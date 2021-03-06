﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform destination;
    public AudioSource teleportSFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
                other.transform.gameObject.GetComponent<CharacterController>().enabled = false;
                other.transform.gameObject.transform.position = destination.position;
                other.transform.gameObject.GetComponent<CharacterController>().enabled = true;
            // play sfx for teleport    
            if (!teleportSFX.isPlaying)
                teleportSFX.Play();
        }
    }




}
