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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();        
        sword = GameObject.Find("Sword");
    }

    // Update is called once per frame
    void Update()
    {
       
        // Swing
        if (Input.GetMouseButtonDown(0))
        {
            swingSword();
        }

        // Dash
        if (Input.GetMouseButtonDown(1))
        {
            dash();
        }
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
}
