
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int gravityDir;

    [SerializeField]
    private int force;
    private Rigidbody2D playerRB;
    private PlayerStatus status;
    private PlayerInputs playerInput;

    private void Awake()
    {
        playerInput = new PlayerInputs();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        status = gameObject.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();

    }

    void Update(){
        CheckAir();
        Jump();
    }


    /// <summary>
    /// Read values from <b><paramref name="playerInput"/></b>, and assigns value on X<br/>
    /// if value on X is diferent from 0, asigns a direction in X and sets a movement step for the character
    /// </summary>
    private void Movement(){
        Vector2 movementInput = playerInput.PlayerMain.Movement.ReadValue<Vector2>();
        float dirX= movementInput.x;
        
        if(dirX == 0){
            dirX = 0; 
        }

        Vector2 movementStepX = new Vector2(dirX * speed, playerRB.velocity.y);
        playerRB.velocity = movementStepX;
    }

    /// <summary>
    /// Gets player status and checks if it is on the ground, if the player input was a jump<br/>
    /// adds a force in +Y to the player rigid body and sets status to jump
    /// </summary>
    private void Jump(){
        PlayerStatus.Status currentStatus = status.getStatus();
        if (playerInput.PlayerMain.Jump.triggered && currentStatus == PlayerStatus.Status.ground)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x,0f);
            playerRB.AddForce(new Vector2(0,force), ForceMode2D.Impulse);
            status.setStatus(PlayerStatus.Status.jump);
        }
    }

    /// <summary>
    /// If player the velocity of player is < 0 that means it is falling, so status changes to <b>air</b>
    /// </summary>
    private void CheckAir(){
        if(playerRB.velocity.y*gravityDir<0){
            status.setStatus(PlayerStatus.Status.air);
        }
    }


    /// <summary>
    /// Uses the information stored in <b>col</b>, to get the tag and normal of the collision<br/>
    /// If the normal in x is 0, that means the collision was in the top or the bottom of the obstacle<br/>
    /// that means the collision was with the ground and not a wall so state can change to <b>ground</b><br/>
    /// Input: <b><paramref name="col"></paramref></b>
    /// </summary>
    void OnCollisionEnter2D(Collision2D col){

        String colTag = col.collider.tag;
        Vector2 contactNormal =  col.GetContact(0).normal;

        if (colTag == "ground" && contactNormal.x==0){
            status.setStatus(PlayerStatus.Status.ground);
        }
    }
}
