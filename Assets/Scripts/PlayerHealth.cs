using System;
using System.Collections;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 10;
    public Boolean invulnerable;
    public GameObject deathmenu;
    public GameObject HUD;
    public Animator animator;
    public bossScript enemyhealth;
    public GameObject winMenu;

    public void Update()
    {
        if (enemyhealth.Currenthealth == 0)
        {
            animator.SetTrigger("Win");
            StartCoroutine(won());
        }
    }

    public void damage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animator.SetTrigger("Death");
            StartCoroutine(dead());
        }
    }
    
    public void setHealth(int health)
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
    
    IEnumerator dead()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
        deathmenu.SetActive(true);
        HUD.SetActive(false);

    }

    IEnumerator won()
    {
        
        yield return new WaitForSeconds(3.0f);
        HUD.SetActive(false);
        winMenu.SetActive(true);
        
        

    }
}