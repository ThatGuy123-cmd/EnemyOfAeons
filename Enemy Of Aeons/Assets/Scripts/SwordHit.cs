using System;
using UnityEngine;

public class SwordHit : MonoBehaviour {
    public int damage = 1;

    public void OnCollisionEnter(Collision other) {
        Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
        
        if(other.gameObject.CompareTag("minion")){ 
            Debug.Log("working");
            other.gameObject.GetComponent<mainHealth>().damage(1);
          //  Debug.Log("working");
            enemyRigidbody.AddForce(awayFromPlayer * 6, ForceMode.Impulse);
        }    
        else if (other.gameObject.CompareTag("demonlord")){
            other.gameObject.GetComponent<bossScript>().damage(damage);
            Debug.Log("working");
            enemyRigidbody.AddForce(awayFromPlayer * 2, ForceMode.Impulse);
        }
        else if (other.gameObject.CompareTag("Jaguar")){
            other.gameObject.GetComponent<bossScript>().damage(damage);
            Debug.Log("working");
            enemyRigidbody.AddForce(awayFromPlayer * 2, ForceMode.Impulse);
        }
        else if (other.gameObject.CompareTag("warlock")){
            other.gameObject.GetComponent<bossScript>().damage(damage);
            Debug.Log("working");
            enemyRigidbody.AddForce(awayFromPlayer * 2, ForceMode.Impulse);
        }
        else if (other.gameObject.CompareTag("pillar")){
            Destroy(GameObject.FindWithTag("pillar"));
            other.gameObject.GetComponent<mainHealth>().damage(damage);
            Debug.Log("working");
        }
    }
}
