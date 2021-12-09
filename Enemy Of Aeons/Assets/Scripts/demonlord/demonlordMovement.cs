using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class demonlordMovement : MonoBehaviour
{
    public float speed = 2.0f, dist = 2.0f;
    public Rigidbody demonlordBody;
    public GameObject player;
    public Vector3 lookDirection;

    public float Currenthealth = 5;
    public float Maxhealth = 1;

    public Slider slider;
    
    public GameObject healthBar;
    public int counter = 5;
    
    // Start is called before the first frame update
    void Start() {
        demonlordBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
        
        Currenthealth = Maxhealth;
        slider.value = CalculateHealth();
    
    }


// Update is called once per frame
    void Update()
    { 
        
        slider.value = CalculateHealth();

        // ***  Insert to call next scene when main enemy is dead  ***
       
        
        if(Currenthealth <= 0){
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
        
        Move();
        fallDeath();
    }
    float CalculateHealth(){
        return Currenthealth/Maxhealth;
    }

    public void damage(float damage){
        Currenthealth -= damage;

        if(Currenthealth <=0){
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
            
    }
    public void Move()
    {
        lookDirection = player.transform.position-transform.position;
        
        demonlordBody.AddForce(lookDirection.normalized * speed);

       
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){

            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 

            other.gameObject.GetComponent<PlayerHealth>().damage(1);

            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            //counter +=2;
        }
    }
    
    void fallDeath()
    {
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

}
