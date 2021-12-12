using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScripts : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float reach = 1.0f;
<<<<<<< HEAD
    public float damage = 1.0f;
=======
    public int dmg;

>>>>>>> cf01b76cde84b8884d16e389affbe57261033221
    public LayerMask enemyLayer;

    public AudioSource source;
    public AudioClip swing;
    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<Arena>();
    }

    //Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            swingSword();
        }
    }

    public void swingSword()
    {
        source.GetComponent<AudioSource>().PlayOneShot(swing);
        
        animator.SetTrigger("Attack");
        Collider[] hit = Physics.OverlapSphere(attackPoint.position, reach, enemyLayer);

        
        foreach (var enemy in hit)
        {
            
            //Debug.Log("Hit" + enemy.tag);
            if (enemy.CompareTag("Missile"))
            {
                enemy.GetComponent<MissileControl>().setDeflected();
            }
            else
            {
<<<<<<< HEAD
                enemy.gameObject.GetComponent<mainHealth>().damage(5);
=======
                enemy.GetComponent<EnemyHealth>().damage(dmg);
>>>>>>> cf01b76cde84b8884d16e389affbe57261033221
            }
        }

    }
    
    // Debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, reach);
    }
    
}

