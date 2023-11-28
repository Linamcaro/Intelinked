using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VioletAnimation : MonoBehaviour
{
    Animator violetAnimator;

    CharacterMovement violetStatus;
    // Start is called before the first frame update
    void Start()
    {
        violetAnimator = GameObject.FindGameObjectWithTag("PlayerDown").GetComponent<Animator>();
        violetStatus = GameObject.FindGameObjectWithTag("PlayerDown").GetComponent<CharacterMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimation();
    }

    private void ChangeAnimation(){
        if (violetStatus.IsWalking()){
            violetAnimator.SetBool("isWalking", true);
        }
        else
        {
            violetAnimator.SetBool("isWalking", false);
            
        }
        if (violetStatus.IsJumping()){
            violetAnimator.SetBool("isJumping", true);
        }
        else
        {
            violetAnimator.SetBool("isJumping", false);
            
        }

        
    }
}
