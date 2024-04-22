using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    public PlayerController pc;

    public float timer;
    void Start()
    {
        timer = 0;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && pc.currentOrientation == PlayerController.Orientations.StraightUp)
        {
            timer += Time.deltaTime;
            if(timer > 0.1f)
            {
                timer = 0;
                pc.resetPlayer();
                
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        timer = 0;
    }


}
