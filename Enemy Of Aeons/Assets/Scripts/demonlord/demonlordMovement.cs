using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonlordMovement : MonoBehaviour
{
    public float speed = 2.0f, dist = 2.0f;
    public Rigidbody demonlordBody;
    public GameObject player;
    public Vector3 lookDirection;


    // Start is called before the first frame update
    void Start() {
        demonlordBody = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }


// Update is called once per frame
    void Update()
    { 
        Move();
    }
    
    public void Move()
    {
        lookDirection = player.transform.position-transform.position;
        
        demonlordBody.AddForce(lookDirection.normalized * speed);

        if (Vector3.Distance(transform.position, player.transform.position) < dist)
        {
            demonlordBody.AddForce(lookDirection, ForceMode.Impulse);
        }
    }

}
