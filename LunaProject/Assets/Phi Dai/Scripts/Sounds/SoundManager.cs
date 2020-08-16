using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Can be changed to variables/list if needed
    public AudioSource footStep;
    public AudioSource jump;
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
                StopAll();
                break;
            case (Audio.footStepSFX):
                //recheck intervals
                if (!footStep.isPlaying)
                    footStep.Play();
                break;
            case (Audio.jumpSFX):
                break;
               // if (!jump.isPlaying)
                   
                break;
            case (Audio.interactSFX):
                StopAll();
                break;
            }
    }
  
    void StopAll()
    {
        if (footStep.isPlaying)
            footStep.Stop();
        if (jump.isPlaying)
            jump.Stop();
    }
  
}
