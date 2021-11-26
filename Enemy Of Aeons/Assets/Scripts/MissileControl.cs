using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    // Tuning
    public float speed = 3.0f;
    private GameObject player;
    private Vector3 target;
    private Boolean deflected;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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
        target = GameObject.Find("TurtleTank").transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, 1.0f * speed * Time.deltaTime);
    }
    
}
