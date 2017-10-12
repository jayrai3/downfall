using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaperCollect : MonoBehaviour
{
    public int paper = 0;
    public int paperToWin = 10;

    public AudioClip collectSound;

    public GameObject paperLabel;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Paper")
        {
            GetComponent<AudioSource>().PlayOneShot(collectSound);

            paper += 1;
            Debug.Log("Paper was picked up, total papers: " + paper);
            Destroy(other.gameObject);
        }
    }

    void OnGUI()
    {
        Text Paper = paperLabel.GetComponent<Text>();

        if (paper < paperToWin)
        {
            Paper.text = paper.ToString() + " / 10";
        }
        else
        {
            Paper.text = "All papers collected!";

            SceneManager.LoadScene(3);
        }    
    }
}
