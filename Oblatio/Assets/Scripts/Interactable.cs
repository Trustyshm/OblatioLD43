using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour {

    public Item item;
    public Transform player;
    public Camera cam;
    private GameObject pickSound;
    private AudioSource pickPlayer;
    // private GameObject prompt;

    private void Start()
    {
        pickSound = GameObject.FindGameObjectWithTag("PickMe");
        pickPlayer = pickSound.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            float distances = Vector3.Distance(player.position, transform.position);
            if (distances <= 2)
            {
                PickUp();
            }
           
        }
       
    }

    public void PickUp()
    {
        bool wasPickedUp = InventoryManager.instance.Add(item);

        if (wasPickedUp)
        {
            pickPlayer.Play();
            Destroy(gameObject);
        }
        
    }


}
