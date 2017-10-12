using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlVoices : MonoBehaviour
{
    public AudioSource Audio;

    //Use this for initialization

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Audio.Play();
    }

}
