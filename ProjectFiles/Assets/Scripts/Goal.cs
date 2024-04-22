using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public PlayerController pc;
    public string nextLevel;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && pc.currentOrientation == PlayerController.Orientations.StraightUp)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

}
