using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 10;
    //public float Maxhealth;
    public Boolean invulnerable;

    public GameObject deathmenu;
    public GameObject HUD;

    //public Slider slider;

    //public GameObject healthBar;


    // Start is called before the first frame update
    void Start()
    {
        //health = Maxhealth;
        //slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value = CalculateHealth();

        // ***  Insert to call next scene when main enemy is dead  ***
        // if (active = false){
        //     SceneManager.LoadScene("");
        // }
    }

    // float CalculateHealth()
    // {
    //     return health / Maxhealth;
    // }

    public void damage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            deathmenu.SetActive(true);
            HUD.SetActive(false);
            
            
        }
    }
    
    public void setHealth(float health)
    {
        currentHealth += health;
    }

    public void makeInvulnerable()
    {
        invulnerable = true;
    }

    public void voidInvulnerable()
    {
        invulnerable = false;
    }

//Enemy health bar reference 
//    https://www.youtube.com/watch?v=ZYeXmze5gxg


    // *** Can also be used in Enemy script to do damage to player *** 
    // *** When hit by sword *** (Insert into player to call game object with damage script and pass damage amount to damage method) 
    // *** 1. Will inflict <damage> by calling damage method from HealthScriptName script *** 
    // *** 2. Will knock back enemy with force multiplied by 10 when hit *** 
    // ***  Enemy sword should have isTrigger enabled  ***
    // void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.CompareTag("demonlord")){
    //         Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
    //         Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 
    //
    //         other.gameObject.GetComponent<demonlordHealth>().damage(1);
    //
    //         enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
    //     }
    // }
}