using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Can be changed to variables/list if needed
    public AudioSource footStep;
    public enum Audio { none, footStepSFX, jumpSFX, interactSFX}
    public static Audio audioState;   

    void Update()
    {
        //Debug.Log("State of audio: " + audioState);
        PlayAudioOnState();
    }


    void PlayAudioOnState()
    {
        switch (audioState)
        {
            case (Audio.none):
                break;
            case (Audio.footStepSFX):              
                //recheck intervals
                    StartCoroutine(FootStepInterval());
                break;
            case (Audio.jumpSFX):
                break;
            case (Audio.interactSFX):
                break;
        }
    }
   
    IEnumerator FootStepInterval()
    {      
        if (!footStep.isPlaying)
            footStep.Play();
        yield return new WaitForSeconds(1f);
    }
  
}
