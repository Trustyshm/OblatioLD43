using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepExplode : MonoBehaviour {

    public AnimationClip explode;
    public ParticleSystem animalExplode;
    public GameObject sheep;

    private GameObject sheepSound;
    private AudioSource sheepPlayer;
    private GameObject afterDeathSound;
    private AudioSource afterDeathPlayer;

    private float destroyTimer = 0.7f;
    private bool toDestroy = false;

    // Use this for initialization
    void Start()
    {
        sheepSound = GameObject.FindGameObjectWithTag("DyingSheep");
        sheepPlayer = sheepSound.GetComponent<AudioSource>();
        afterDeathSound = GameObject.FindGameObjectWithTag("AfterDeath");
        afterDeathPlayer = afterDeathSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

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


    public void ExplodingSheep()
    {
        this.GetComponent<AnimalWander>().beingFed = true;
        //  gameObject.GetComponent<Animator>().Play("SheepExplode");
        Instantiate(animalExplode, sheep.transform.position, Quaternion.identity);
        sheepPlayer.Play();
        toDestroy = true;
    }
}
