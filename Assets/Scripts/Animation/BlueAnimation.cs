using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAnimation : MonoBehaviour
{

    Animator blueAnimator;

    CharacterMovement blueStatus;
    // Start is called before the first frame update
    void Start()
    {
        blueAnimator = GameObject.FindGameObjectWithTag("PlayerTop").GetComponent<Animator>();
        blueStatus = GameObject.FindGameObjectWithTag("PlayerTop").GetComponent<CharacterMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimation();
    }

    private void ChangeAnimation(){
        if (blueStatus.IsWalking()){
            blueAnimator.SetBool("isWalking", true);
        }
        else
        {
            blueAnimator.SetBool("isWalking", false);
            
        }
        if (blueStatus.IsJumping()){
            blueAnimator.SetBool("IsJumping", true);
        }
        else
        {
            blueAnimator.SetBool("IsJumping", false);
            
        }

        
    }


}
