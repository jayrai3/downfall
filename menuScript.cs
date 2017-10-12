using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas optionsMenu;
    public Canvas helpMenu;
    public Canvas creditsMenu;
    public Button startText;
    public Button exitText;
    public Button closeTextHelp;

    public Image black;
    public Animator anim;

    private AudioSource audioSource;

    public Canvas startCanvas;
    
	// Use this for initialization
	void Start ()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        helpMenu = helpMenu.GetComponent<Canvas>();
        creditsMenu = creditsMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
        optionsMenu.enabled = false;
        helpMenu.enabled = false;
        creditsMenu.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        optionsMenu.enabled = false;
        helpMenu.enabled = false;
        creditsMenu.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        optionsMenu.enabled = false;
        helpMenu.enabled = false;
        creditsMenu.enabled = false;
    }

    public void OptionsPress()
    {
        optionsMenu.enabled = true;
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = false;
        helpMenu.enabled = false;
        creditsMenu.enabled = false;
    }

    public void HelpPress()
    {
        optionsMenu.enabled = false;
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = false;
        helpMenu.enabled = true;
        creditsMenu.enabled = false;
    }

    public void CreditsPress()
    {
        optionsMenu.enabled = false;
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = false;
        helpMenu.enabled = false;
        creditsMenu.enabled = true;
    }

    public void CloseHelp()
    {
        helpMenu.enabled = false;
    }

    public void CloseCredits()
    {
        creditsMenu.enabled = false;
    }

    public void StartLevel()
    {
        audioSource.Stop();

        startCanvas.GetComponent<Canvas>().enabled = false;
        optionsMenu.enabled = false;
        quitMenu.enabled = false;
        helpMenu.enabled = false;
        creditsMenu.enabled = false;

        LoadingScreen.show();

        Application.LoadLevel("game");
        //StartCoroutine(Fading());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
		
	}
}
