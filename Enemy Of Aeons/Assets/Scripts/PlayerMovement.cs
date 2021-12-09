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
        float horizontalInput = Input.GetAxis("Horizontal");
        // Dash
        if (Input.GetMouseButtonDown(1))
        {
            dash();
        }
        transform.Translate(transform.right * horizontalInput * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector3 playerPos = transform.position; 
        // Basic Movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        
        transform.Translate(transform.right * horizontalInput * speed * Time.deltaTime);
        movePlayer(verticalInput, horizontalInput);
        playerRb.MovePosition(playerPos + transform.forward * verticalInput * speed * Time.deltaTime);
    }

    public void movePlayer(float movingV, float movingH)
    {
        if (movingV != 0 || movingH != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move",false);
        }
    }

    public void dash()
    {
        
    }
}
