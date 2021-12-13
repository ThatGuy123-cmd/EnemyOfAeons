using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionHandler : MonoBehaviour
{
    
    // Tuning
    public float aoeRadius = 1.5f;
    // Relations
    GameObject player;
    public PlayerHealth playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grenade"))
        {
            grenadeExplosion();
            Destroy(gameObject);
        }
        else if (CompareTag("Cover"))
        {
            Debug.Log("Swept");
        }
        
        /*
        else if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.makeInvulnerable();
        }
        */
    }

   /*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.voidInvulnerable();
        }
    }
 */
    private void OnCollisionEnter(Collision other)
    {
        if (CompareTag("Cover"))
        {
            Debug.Log("HitCover");    
        }
        
    }

    void grenadeExplosion()
    {
        // Max number of handled collisions in one instance of explosion
        int maxCollision = 4;
        Collider[] aoeAffected = new Collider[maxCollision];
        int countCollisions = Physics.OverlapSphereNonAlloc(transform.position, aoeRadius, aoeAffected);
        for (int i = 0; i < countCollisions; i++)
        {
            Debug.Log("Hit by AOE");
            //aoeAffected[i].SendMessage("calcHit");
        }
    }
}
