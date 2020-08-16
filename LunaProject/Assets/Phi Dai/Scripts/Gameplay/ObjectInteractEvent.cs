using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractEvent : MonoBehaviour
{

    public GameObject assetToDisable;
    public AudioSource interactedSFX;
    public bool interacted = false;

    void Update()
    {      
      // destroy it and disable asset
       if(interacted)
           ObjEventDestroy();
       
    }

    void ObjEventDestroy()
    {
        Debug.Log("Destroyed asset");
        interactedSFX.Play();
        assetToDisable.SetActive(false);
        Destroy(this.gameObject);
    }


}
