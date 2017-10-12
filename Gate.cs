using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool open = false;

    public float doorOpenAngle = 90.0f;
    public float doorClosedAngle = 0.0f;

    private AudioSource audioSource;
    public AudioClip openingSound;
    public AudioClip lockedSound;

    public bool isLocked = false;
    public GameObject gateText;
    public float gateTextTime = 2.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gateText.SetActive(false);
    }

    //Speed of the rotation.
    public float smooth = 1.0f;

    public void ChangeDoorState()
    {
        if(isLocked != true)
        {
            open = !open;

            if (audioSource != null)
            {
                audioSource.PlayOneShot(openingSound, 0.4f);
            }
        }
        else
        {
            audioSource.PlayOneShot(lockedSound, 0.4f);
            gateText.SetActive(true);
            Destroy(gateText, gateTextTime);
        }

    }

    // Update is called once per frame
    void Update()
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
