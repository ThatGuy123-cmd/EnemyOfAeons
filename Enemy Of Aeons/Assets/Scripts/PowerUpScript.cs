using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public int health = 2;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Sword"))
        {
            Debug.Log("yes");
            other.gameObject.GetComponent<PlayerHealth>().setHealth(health);
            Destroy(gameObject);
            //other.gameObject.GetComponent<mainHealth>().setHealth(1);

        }
    }
}
