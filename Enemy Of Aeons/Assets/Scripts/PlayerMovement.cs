using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private Rigidbody playerRb;
    private GameObject sword;
    public float speed;
    public Collider collider;
    
    public float distToGround;

    public SwordHit swordCall;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();        
        sword = GameObject.Find("Sword");

        //collider = gameObject.CompareTag("floor");
        //GetComponent<Collider>();

        distToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
       
        // Swing
        if (Input.GetMouseButtonDown(0))
        {
            swingSword();
            //swordCall();
        }

        // Dash
        if (Input.GetMouseButtonDown(1))
        {
            dash();
        }

        // if (IsGrounded())
        // {
        //     playerRb.transform.position.y =
        // }
        // else
        //
        // {
        //     playerRb.transform.position.y = 
        // }

        IsGrounded();
        
        zoned();
    }

    private void FixedUpdate()
    {
        Vector3 playerPos = transform.position; 
        // Basic Movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        
        playerRb.MovePosition(playerPos + transform.right * horizontalInput * speed * Time.deltaTime);
        playerRb.MovePosition(playerPos + transform.forward * verticalInput * speed * Time.deltaTime);
    }

    public void swingSword()
    {
        
    }

    public void dash()
    {
    }

   
    
    public bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.down, distToGround + 0.1f);
    }

    public void zoned()
    {
        if (transform.position.z >= 47|| transform.position.z <= 17 || transform.position.x <= -35 || transform.position.x >= 19)
        {
            playerRb.transform.position = new Vector3(-11.89f, 1.8f, 34.32f);

        }
    } 
    
    
}
