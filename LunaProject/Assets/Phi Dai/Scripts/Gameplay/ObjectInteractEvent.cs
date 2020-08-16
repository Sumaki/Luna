using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractEvent : MonoBehaviour
{

    public GameObject assetToDisable;
    public AudioSource interactedSFX;  


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Destroyed asset");
            interactedSFX.Play();
            assetToDisable.SetActive(false);
            Destroy(this.gameObject);
        }
    }


}
