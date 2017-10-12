using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Note : MonoBehaviour
{
    public AudioClip noteCollectSound;

    public GameObject playerObject;

    public Image noteImage;
    public GameObject hideNoteButton;

    // Use this for initialization
    void Start()
    {
        noteImage.enabled = false;
        hideNoteButton.SetActive(false);
    }

    public void ShowNoteImage()
    {
        noteImage.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(noteCollectSound);

        hideNoteButton.SetActive(true);

        playerObject.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideNoteImage()
    {
        noteImage.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(noteCollectSound);

        hideNoteButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerObject.GetComponent<FirstPersonController>().enabled = true;
    }
}
