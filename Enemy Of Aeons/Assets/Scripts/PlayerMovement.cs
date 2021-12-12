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
    public Animator animator;

    
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
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        move();

        if (Input.GetMouseButtonDown(0))
        {
<<<<<<< Updated upstream
            
        }
=======
            scripted.swingSword();
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        // Dash
>>>>>>> Stashed changes
        if (Input.GetMouseButtonDown(1))
        {
            jump();
        }
<<<<<<< Updated upstream
=======


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
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    }

    public void movePlayer(float movingV, float movingH)
    {
<<<<<<< Updated upstream
        scripted.swingSword();
=======

        scripted.swingSword();

>>>>>>> Stashed changes
        if (movingV != 0 || movingH != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move",false);
        }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
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
