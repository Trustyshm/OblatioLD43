using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GodText : MonoBehaviour {

    public GameObject bossPanel;
    public GameObject killed;
    public GameObject knowingly;
    public GameObject button;
    public GameObject what;
    public GameObject expectedBetter;
    public GameObject badPerson;
    public GameObject sacrificeGod;
    public GameObject heyy;

    public GameObject godWasHit;
    public AudioSource godSound;

    public ParticleSystem blood;

    private bool godHit = false;
    public Animator godAnimator;

    public GameObject faderGod;

    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject playerPanel;
   

    public Image bossPanelImage;
    public float timer;
    private bool one = false;
    private bool two = false;
    private bool three = false;
    private bool four = false;
    private bool five = false;
    private bool six = false;
    private bool seven = false;
    private float exitTimer;
    private float sacrificeTimer;

    private bool doOnceOne = false;
    private bool doOnceTwo = false;

    private bool stopButton = false;

    public Animator anim;


	// Use this for initialization
	void Start () {
        bossPanelImage = bossPanel.GetComponent<Image>();
        timer = 7f;
        TextAppearer();
        anim = button.GetComponent<Animator>();
        godAnimator = heyy.GetComponent<Animator>();
        godWasHit = GameObject.FindGameObjectWithTag("GodHit");
        godSound = godWasHit.GetComponent<AudioSource>();
        exitTimer = 6f;
        sacrificeTimer = 5f;
    }
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;
       

        if (timer <= 5 && doOnceOne == false)
        {
            KilledAppearer();
            doOnceOne = true;
        }

        if (timer <= 2 && doOnceTwo == false)
        {
            KnowinglyAppearer();
            
            doOnceTwo = true;
        }

        if (three == true)
        {
            exitTimer -= Time.deltaTime;
        }

        if (six == true)
        {
            sacrificeTimer -= Time.deltaTime;
        }

        if (exitTimer <= 0)
        {
            SceneManager.LoadScene("Menu");
        }

        if (sacrificeTimer <= 0 && !seven)
        {
            Debug.Log("This Happens");
            playerPanel.SetActive(true);
            sacrificeGod.SetActive(true);
            seven = true;
           
        }

        anim.SetBool("StopButton", stopButton);
        godAnimator.SetBool("godHit", godHit);
    }


    void TextAppearer()
    {
        bossPanel.SetActive(true);
        killed.SetActive(false);
        knowingly.SetActive(false);
        what.SetActive(false);
        expectedBetter.SetActive(false);
        badPerson.SetActive(false);
    }

    void KilledAppearer()
    {
        killed.SetActive(true);
    }

    void KnowinglyAppearer()
    {
        knowingly.SetActive(true);
        button.SetActive(true);
    }

    public void TextOne()
    {
        if (one == false)
        {
            knowingly.SetActive(false);
            killed.SetActive(false);
            expectedBetter.SetActive(false);
            badPerson.SetActive(false);
            stopButton = true;
            what.SetActive(true);
            one = true;
            playerPanel.SetActive(true);
            choiceOne.SetActive(true);
            choiceTwo.SetActive(true);
        }

        if (two == true)
        {
            faderGod.SetActive(true);
            three = true;
            five = true;
        }

        if (one && !four)
        {

        }
        

    }

    public void ChoiceOne()
    {
        Debug.Log("Choice One Picked");
        playerPanel.SetActive(false);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        what.SetActive(false);
        expectedBetter.SetActive(false);
        badPerson.SetActive(true);
        six = true;
    }

    public void ChoiceTwo()
    {
        Debug.Log("Choice Two Picked");
        playerPanel.SetActive(false);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        what.SetActive(false);
        expectedBetter.SetActive(true);
        stopButton = false;
        two = true;
    }

    public void SacrificeGod()
    {
        godHit = true;
        sacrificeGod.SetActive(false);
        Instantiate(blood, heyy.transform.position, Quaternion.identity);
        godSound.Play();
        three = true;
        faderGod.SetActive(true);
    }
}
