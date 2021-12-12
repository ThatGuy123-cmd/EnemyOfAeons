using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public int health = 2;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().setHealth(health);
            Destroy(gameObject);
            //other.gameObject.GetComponent<mainHealth>().setHealth(1);

        }
    }
}
