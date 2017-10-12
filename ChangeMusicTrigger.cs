using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicTrigger : MonoBehaviour {

    public AudioSource Audio;

    //Use this for initialization

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource aud in audios)

            aud.volume = 0.0f;

        if (other.tag == "Player")
        {
            Audio.volume = 0.4f;
            Audio.Play();
        }
        else
        {
            Audio.Stop();
        }
    }

}
