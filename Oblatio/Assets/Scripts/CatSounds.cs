using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSounds : MonoBehaviour {

    public AudioClip rabbitOne;
    public AudioClip rabbitTwo;
    public AudioClip rabbitThree;

    public AudioSource rabbitOneSource;
    public AudioSource rabbitTwoSource;
    public AudioSource rabbitThreeSource;

    private float clipCountdown;
    private float clipSelector;

    // Use this for initialization
    void Start()
    {
        rabbitOneSource.clip = rabbitOne;
        rabbitTwoSource.clip = rabbitTwo;
        rabbitThreeSource.clip = rabbitThree;
        clipCountdown = 5;
        clipSelector = 2;
    }

    // Update is called once per frame
    void Update()
    {
        clipCountdown -= Time.deltaTime;
        if (clipCountdown <= 0)
        {
            PlayRandomClip();
            CountdownCreater();
        }

    }

    void CountdownCreater()
    {
        clipCountdown = Random.Range(5, 10);
        clipSelector = Random.Range(1, 3);
    }

    void PlayRandomClip()
    {
       // clipSelector = Random.Range(1, 3);
        if (clipSelector == 1)
        {
            rabbitOneSource.clip = rabbitOne;
            rabbitOneSource.Play();
        }

        if (clipSelector == 2)
        {
            rabbitTwoSource.clip = rabbitTwo;
            rabbitTwoSource.Play(); 
        }

        if (clipSelector == 3)
        {
            rabbitThreeSource.clip = rabbitThree;
            rabbitThreeSource.Play();
        }
    }
}
