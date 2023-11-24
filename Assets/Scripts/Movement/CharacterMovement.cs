
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
        Jump();
    }

    private void Movement(){
        Vector2 movementInput = playerInput.PlayerMain.Movement.ReadValue<Vector2>();
        float dirX= movementInput.x;
        
        if(dirX!=0){
            Vector2 movementStepX = new Vector2(dirX * speed,playerRB.velocity.y);
            playerRB.velocity = movementStepX;
        }
    }

    private void Jump(){
        PlayerStatus.Status currentStatus = status.getStatus();
        if (playerInput.PlayerMain.Jump.triggered && currentStatus == PlayerStatus.Status.ground)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x,0f);
            playerRB.AddForce(new Vector2(0,force), ForceMode2D.Impulse);
            status.setStatus(PlayerStatus.Status.jump);
        }
    }



    void OnCollisionEnter2D(Collision2D col){

        String colTag = col.collider.tag;

        if (colTag == "ground"){
            status.setStatus(PlayerStatus.Status.ground);
        }
    }
}
