using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class allows us to maintain a stable rotation with our character's sprite and will always look at the camera.
/// </summary>
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
