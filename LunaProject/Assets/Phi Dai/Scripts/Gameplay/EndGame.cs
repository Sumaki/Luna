using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject endingCanvas;
    public AudioSource endAudio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            endingCanvas.GetComponentInChildren<Animator>().SetBool("fade", true);
            endAudio.Play();
            StartCoroutine(CloseGame());
        }
    }

    IEnumerator CloseGame()
    {
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}
