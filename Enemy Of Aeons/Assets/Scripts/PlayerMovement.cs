using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    public Animator animator;
    private GameObject sword;
    public float speed;
    public SwordScripts scripted;
    public float jumped = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();        
        sword = GameObject.Find("Sword");

        //swingSword = GetComponent<SwordScripts>().swingSword();
    }

    // Update is called once per frame
    void Update()
    {

        move();

        if (Input.GetMouseButtonDown(0))
        {

            
        }


        float horizontalInput = Input.GetAxis("Horizontal");

        // Dash

        if (Input.GetMouseButtonDown(1))
        {
            jump();
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

        //IsGrounded();
        
        //zoned();

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
