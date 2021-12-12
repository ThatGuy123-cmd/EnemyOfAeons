using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject sword;
    public float speed;
    public SwordScripts scripted;
    public float jumped = 5.0f;
 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();        
        sword = GameObject.Find("Sword");
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (Input.GetMouseButtonDown(0))
        {
            swingSword();
        }
        // Dash
        if (Input.GetMouseButtonDown(1))
        {
            jump();
        }
    }

    public void swingSword()
    {
        scripted.swingSword();
    }

    public void jump()
    {
        playerRb.AddForce(transform.position * jumped, ForceMode.Impulse); 
    }

    public void move()
    {
       
        // Basic Movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }
}
