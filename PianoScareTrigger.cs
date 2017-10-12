using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoScareTrigger : MonoBehaviour {

    public AudioSource scareAudioSource;
    public AudioClip scareSound;
    private bool hasPlayedAudio;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && hasPlayedAudio == false)
        {
            scareAudioSource.PlayOneShot(scareSound);
            hasPlayedAudio = true;
        }
    }

}
