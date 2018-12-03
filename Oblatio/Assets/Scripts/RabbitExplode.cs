using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RabbitExplode : MonoBehaviour {

    public AnimationClip explode;
    public ParticleSystem animalExplode;
    public GameObject rabbit;
    private GameObject rabbitSound;
    private AudioSource rabbitPlayer;
    private GameObject afterDeathSound;
    private AudioSource afterDeathPlayer;

    private float destroyTimer = 0.7f;
    private bool toDestroy = false;

	// Use this for initialization
	void Start () {
        rabbitSound = GameObject.FindGameObjectWithTag("DyingRabbit");
        rabbitPlayer = rabbitSound.GetComponent<AudioSource>();
        afterDeathSound = GameObject.FindGameObjectWithTag("AfterDeath");
        afterDeathPlayer = afterDeathSound.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if (toDestroy)
        {
            destroyTimer -= Time.deltaTime;
        }

        if (destroyTimer <= 0)
        {
            afterDeathPlayer.Play();
            Destroy(gameObject);
        }
	}


    public void ExplodingRabbit()
    {
        this.GetComponent<AnimalWander>().beingFed = true;
        gameObject.GetComponent<Animator>().Play("RabbitExplode");
        Instantiate(animalExplode, rabbit.transform.position, Quaternion.identity);
        rabbitPlayer.Play();
        toDestroy = true;
    }
}
