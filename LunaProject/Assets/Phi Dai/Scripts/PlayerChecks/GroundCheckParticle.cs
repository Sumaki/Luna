using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckParticle : MonoBehaviour
{
    public ParticleSystem cloudDustParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("Playing particle");
            cloudDustParticle.Play();
        }
    }
}
