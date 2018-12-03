using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RabbitSounds : MonoBehaviour {

    public AudioClip rabbitOne;
    public AudioClip rabbitTwo;
    public AudioClip rabbitThree;

    public AudioSource rabbitOneSource;
    public AudioSource rabbitTwoSource;
    public AudioSource rabbitThreeSource;

    private float clipCountdown;
    private float clipSelector;

	// Use this for initialization
	void Start () {
        rabbitOneSource.clip = rabbitOne;
        rabbitTwoSource.clip = rabbitTwo;
        rabbitThreeSource.clip = rabbitThree;
    }
	
	// Update is called once per frame
	void Update () {
        clipCountdown = Random.Range(5f, 15f);
        Debug.Log(clipCountdown);
		
	}
}
