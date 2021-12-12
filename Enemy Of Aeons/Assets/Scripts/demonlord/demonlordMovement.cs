using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class demonlordMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public Rigidbody bossBody;
    public GameObject player;
    public float Currenthealth = 10;
    public float Maxhealth = 10;
    public Slider slider;
    public Animator anim;


    void Start(){
        bossBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
        Currenthealth = Maxhealth;
        slider.value = CalculateHealth();
    }

    
    void Update(){
        slider.value = CalculateHealth();
        
        if(Currenthealth <= 0){
            anim.SetTrigger("Death");
        }

        Move(); 
        fallDeath();
    }
    float CalculateHealth(){
        return Currenthealth/Maxhealth;
    }

    public void damage(float damage){
        Currenthealth -= damage;
    }
    
    public void fallDeath(){
        if (transform.position.y <= -5){
            Currenthealth = 0;
        }
    }
    
    public void Move(){
        Vector3 lookDirection = player.transform.position-transform.position;
        
        bossBody.AddForce(lookDirection.normalized * speed);
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){

            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 

            other.gameObject.GetComponent<PlayerHealth>().damage(1);

            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
        }
    }
}
