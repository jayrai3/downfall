using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Documents : MonoBehaviour
{
    public Image documentImage;

    public AudioClip pickupSound;

    public GameObject playerObject;
    public GameObject kevinParasite;
    public AudioClip scareSound;

    // Use this for initialization
    void Start()
    {
        documentImage.enabled = false;
    }

    public void ShowDocumentImage()
    {
        documentImage.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(pickupSound);

        playerObject.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerObject.GetComponent<FirstPersonController>().enabled = true;

            GetComponent<AudioSource>().PlayOneShot(scareSound);

            documentImage.enabled = false;
            kevinParasite.SetActive(true);
        }
    }
}
