using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    private CharacterMovement player;
    //Check if can play the sound
    private bool canPlaySound = true;

    private void Awake()
    {
        player = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsJumping() && canPlaySound)
        {
            StartCoroutine(PlaySound());
            AudioManager.Instance.PlayJumpSound();
        }
    }
    IEnumerator PlaySound()
    {
        canPlaySound = false;
        yield return new WaitForSeconds(0.1f);
        canPlaySound = true;
    }

}
