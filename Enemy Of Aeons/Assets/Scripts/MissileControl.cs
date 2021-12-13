using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    // Tuning
    public float speed = 3.0f;
    private GameObject player;
    private GameObject turtle;
    private Vector3 target;
    private Boolean deflected;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        turtle = GameObject.Find("Turtle");
    }

    // Update is called once per frame
    void Update()
    {
        if (!deflected)
        {
            homing();
        }
        else
        {
            backToSender();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Sword"))
        {
            Debug.Log("DEFLECTED");
            deflected = true;
        }

        if (other.GetComponent<Collider>().CompareTag("Turtle") && deflected)
        {
            other.GetComponent<EnemyHealth>().damage(2);
            Destroy(gameObject);
        }
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().damage(2);
            Destroy(gameObject);
        }
        
    }

    public void setDeflected()
    {
        deflected = true;
    }
    void homing()
    {
        target = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, 1.0f * speed * Time.deltaTime);
    }

    void backToSender()
    {
        target = turtle.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, 1.0f * speed * Time.deltaTime);
    }
    
}
