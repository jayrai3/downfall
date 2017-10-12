using UnityEngine;
using System.Collections;

public class TvScareEvent : MonoBehaviour
{

    public Texture2D noiseTexture;
    public Texture2D scareTexture;
    public AudioClip noiseSound;
    public AudioClip Scaresound;
    public float scareTime = 3f;

    AudioSource audio;
    bool showscare = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.mainTexture = scareTexture;
            audio.Stop();
            audio.loop = false;
            audio.clip = Scaresound;
            audio.volume = 1f;
            audio.Play();

            showscare = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showscare)
        {
            scareTime -= Time.deltaTime;
            if (scareTime <= 0)
            {
                GetComponent<Renderer>().material.mainTexture = noiseTexture;
                audio.Stop();
                audio.loop = true;
                audio.clip = noiseSound;
                audio.volume = 0.3f;
                audio.Play();

                showscare = false;
            }
        }
    }
}