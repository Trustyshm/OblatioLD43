using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatExplode : MonoBehaviour {

    public AnimationClip explode;
    public ParticleSystem animalExplode;
    public GameObject cat;


    private GameObject catSound;
    private AudioSource catPlayer;
    private GameObject afterDeathSound;
    private AudioSource afterDeathPlayer;

    private float destroyTimer = 0.7f;
    private bool toDestroy = false;

    // Use this for initialization
    void Start()
    {
        catSound = GameObject.FindGameObjectWithTag("DyingCat");
        catPlayer = catSound.GetComponent<AudioSource>();
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


    public void ExplodingCat()
    {
        this.GetComponent<AnimalWander>().beingFed = true;
        gameObject.GetComponent<Animator>().Play("CatExplode");
        Instantiate(animalExplode, cat.transform.position, Quaternion.identity);
        catPlayer.Play();
        toDestroy = true;
    }
}
