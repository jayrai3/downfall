using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorSound : MonoBehaviour {

    public GameObject player;

    public AudioSource doctorMusic;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource aud in audios)

            aud.mute = false;

        doctorMusic.volume = 0.4f;
        doctorMusic.Play();

    }

    private void OnTriggerExit(Collider other)
    {
        AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource aud in audios)

            aud.volume = 1.0f;
    }
}
