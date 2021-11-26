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
        // Basic Movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        
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

    public void swingSword()
    {
        
    }

    public void dash()
    {
    }
}
