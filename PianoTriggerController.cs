using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoTriggerController : MonoBehaviour {

    public AudioSource pianoSound;
    
    // Use this for initialization
	void Start ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pianoSound.Play();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
