
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
    private float speed=1;
    [SerializeField]
    private int force = 0;
    private Rigidbody2D playerRB;
    private PlayerStatus status;

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
        float dirX= Input.GetAxis("Horizontal");
        
        if(dirX!=0){
            Vector3 movementStepX = new Vector3(1,0,0) * speed * Time.fixedDeltaTime* dirX;
            transform.position += movementStepX;
        }
    }

    private void Jump(){
        PlayerStatus.Status currentStatus = status.getStatus();
        if (Input.GetKeyDown("space") && currentStatus == PlayerStatus.Status.ground){
            playerRB.AddForce(Vector2.up * force,ForceMode2D.Impulse);
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
