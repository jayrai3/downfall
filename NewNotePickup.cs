using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class NewNotePickup : MonoBehaviour
{
    public int paper = 0;
    public int paperToWin = 5;

    public AudioClip noteSound;
    public GameObject noteLabel;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Note")
        {
            GetComponent<AudioSource>().PlayOneShot(noteSound);

            paper += 1;
            Debug.Log("Paper was picked up, total papers: " + paper);
            Destroy(other.gameObject);
        }
    }

    void OnGUI()
    {
        Text Paper = noteLabel.GetComponent<Text>();

        if (paper < paperToWin)
        {
            Paper.text = paper.ToString() + " / 5";
        }
        else
        {
            Paper.text = "All Notes Collected!";
        }
    }
}
