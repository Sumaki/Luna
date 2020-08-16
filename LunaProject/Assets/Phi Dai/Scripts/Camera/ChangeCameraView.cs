using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraView : MonoBehaviour
{

    public float cameraZAxisValue;
    float defaultCameraZValue;

    private void Start()
    {
        defaultCameraZValue = Camera.main.GetComponent<CameraFollow>().offset.z;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("triggered");
            Camera.main.GetComponent<CameraFollow>().offset.z = cameraZAxisValue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("send back to default value");
            Camera.main.GetComponent<CameraFollow>().offset.z = defaultCameraZValue;
        }
    }
}
