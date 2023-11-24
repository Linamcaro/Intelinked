using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class Objective : MonoBehaviour
{
    private bool topTrigger = false;
    private bool bottomTrigger = false;

    private string topPlayerTag = "PlayerTop";
    private string bottomPlayerTage = "PlayerDown";


    //If both character triggers the objective is complete

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == topPlayerTag)
        {
            topTrigger = true;
        }

        if(collision.tag == bottomPlayerTage)
        {
            bottomTrigger = true;
        }

        if(topTrigger && bottomTrigger)
        {
            LevelManager.Instance.LoadNextLevel();
        }
    }

    //if character leaves the objective, remove the trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == topPlayerTag)
        {
            topTrigger = false;
        }
        if (collision.tag == bottomPlayerTage) { 
            bottomTrigger = false; 
        }
    }

}
