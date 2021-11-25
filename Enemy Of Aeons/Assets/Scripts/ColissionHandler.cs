using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionHandler : MonoBehaviour
{
    
    // Tuning
    public float aoeRadius = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Grenade"))
        {
            grenadeExplosion();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);    
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
