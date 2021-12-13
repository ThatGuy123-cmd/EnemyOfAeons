using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScripts : MonoBehaviour
{
    public Animator animator;
    public Rigidbody playerRb;
    public Transform attackPoint;
    public float reach = 1.0f;
    
    public float damage = 1.0f;
    public int dmg;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(transform.position * 2, ForceMode.Impulse);
            //jump();
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
                enemy.gameObject.GetComponent<mainHealth>().damage(5);
            }
        }

    }
    
    // Debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, reach);
    }
    
}

