using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public String[] bossNames = {"Jaguar", "Dragon", "Warlock", "TurtleTank", "demonlord", "minion"};
    public float damage = 1.0f;
    public void OnCollisionEnter(Collision other) {

        //if (Input.GetMouseButtonDown(0))
        //{
           // for (int i = 0; i >= bossNames.Length; i++)
           // {
            if(other.gameObject.CompareTag("minion") && Input.GetMouseButtonDown(0)){
                
                GameObject boss = GameObject.FindWithTag("minion");

                
                Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
                
                boss.GetComponent<mainHealth>().damage(damage);
                
                Debug.Log("working");

                enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            }    
            else if (other.gameObject.CompareTag("demonlord"))
            {
                GameObject boss = GameObject.FindWithTag("demonlord");

                
                Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
                
                boss.GetComponent<demonlordMovement>().damage(damage);
                
                Debug.Log("working");

                enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            }
           // }
        
            //Debug.Log("working");
        //}
        
       
    }
}
