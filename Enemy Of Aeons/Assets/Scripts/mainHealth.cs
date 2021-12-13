using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class mainHealth : MonoBehaviour
{
    public float Currenthealth = 5;
    public Animator animator;
    public int counter = 5;

    void Update(){
        if(Currenthealth <= 0f){
            animator.SetTrigger("Die");
            Destroy(gameObject);
        }
    }

    public void damage(float damage){
        Currenthealth -= damage;

        if(Currenthealth <=0){
            Destroy(gameObject);
        }
    }

    

//Enemy health bar reference 
//    https://www.youtube.com/watch?v=ZYeXmze5gxg

    

    // *** Can also be used in Enemy script to do damage to player *** 
    // *** When hit by sword *** (Insert into player to call game object with damage script and pass damage amount to damage method) 
    // *** 1. Will inflict <damage> by calling damage method from HealthScriptName script *** 
    // *** 2. Will knock back enemy with force multiplied by 10 when hit *** 
    // ***  Enemy sword should have isTrigger enabled  ***
    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            animator.SetTrigger("Attack 01");
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 
            
            
            other.gameObject.GetComponent<PlayerHealth>().damage(1);

            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            counter +=2;
        }
    }
}
