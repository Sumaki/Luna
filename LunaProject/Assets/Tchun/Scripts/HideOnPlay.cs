using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Simple script used to hide the View Visualisation plane during the game
 */ 
public class HideOnPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }
}
