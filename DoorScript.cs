using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public bool open = false;

    public float doorOpenAngle = 90.0f;
    public float doorClosedAngle = 140.0f;

    private AudioSource audioSource;
    public AudioClip openingSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Speed of the rotation.
    public float smooth = 2.0f;

    public void ChangeDoorState()
    {
        open = !open;

        if(audioSource != null)
        {
            audioSource.PlayOneShot(openingSound, 0.4f);
        }
    }

    // Update is called once per frame
	void Update ()
    {
        if (open)
        {
            //Open the door here.
            Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

        }
        else
        {
            Quaternion targetRotationClose = Quaternion.Euler(0, doorClosedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClose, smooth * Time.deltaTime);
            
        }	
	}
}
