using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;

    public AudioSource backgroundMusic;

    public Slider healthSlider;

    //public Image damageImage;
    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public AudioClip deathClip;

    bool isDead;
    bool damaged;
    AudioSource playerAudio;

    public Transform destination; //Respawn positon.
    public Transform player;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
        playerAudio = GetComponent<AudioSource>();
        backgroundMusic = GetComponent<AudioSource>();
	}

    void update()
    {
        //if (damaged)
        //{
        //    damageImage.color = flashColour;
        //}
        //else
        //{
        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        //}
        //damaged = false;
    }
	
	public void TakeDamage(int _damage)
    {
        //Debug.Log("Why am I losing health randomly?");

        //damaged = true;
        currentHealth -= _damage;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0)
        {
            currentHealth = maxHealth;
            healthSlider.value = currentHealth;

            Respawn();
        }
    }

    void Die()
    {
        isDead = true;

        playerAudio.clip = deathClip;
        playerAudio.Play();

        Respawn();

        //Load game over screen
        //SceneManager.LoadScene("game_over");
    }

    void Respawn()
    {
        AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource aud in audios)

            aud.volume = 0.0f;

        player.transform.position = destination.position;
    }
}
