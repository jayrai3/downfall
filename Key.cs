using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public Gate myGate;

    public AudioClip keyPickup;
    private AudioSource audioSource;

    public GameObject text1;
    public GameObject keyCharacter;
    public GameObject keyCharacter2;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        text1.active = false;
    }

    public void unlockGate()
    {
        text1.active = true;

        keyCharacter.SetActive(true);
        keyCharacter2.SetActive(true);

        myGate.isLocked = false;
        audioSource.PlayOneShot(keyPickup);

        StartCoroutine("WaitForDestroy");
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(keyPickup.length);
        Destroy(gameObject);
        text1.active = false;

        keyCharacter.SetActive(false);
        keyCharacter2.SetActive(false);
    }
}
