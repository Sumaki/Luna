using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFaceCamera : MonoBehaviour
{
    Quaternion initRot;

    void Start()
    {
        initRot = transform.rotation;
    }
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }

    private void LateUpdate()
    {
        transform.rotation = initRot;
    }
}
