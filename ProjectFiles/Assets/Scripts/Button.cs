using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public PlayerController pc;
    public GameObject buttonPlatform;
    public GameObject deathBlocks;


    public bool straightUp;
    public bool active;


    void Start()
    {
        active = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!straightUp)
            {
                if (active)
                {
                    buttonPlatform.SetActive(false);
                    deathBlocks.SetActive(true);
                    active = false;
                }
                else
                {
                    buttonPlatform.SetActive(true);
                    deathBlocks.SetActive(false);
                    active = true;
                }
            }
            else if (straightUp && pc.currentOrientation == PlayerController.Orientations.StraightUp)
            {
                if (active)
                {
                    buttonPlatform.SetActive(false);
                    deathBlocks.SetActive(true);
                    active = false;
                }
                else
                {
                    buttonPlatform.SetActive(true);
                    deathBlocks.SetActive(false);
                    active = true;
                }
            }
        }
    }

}
