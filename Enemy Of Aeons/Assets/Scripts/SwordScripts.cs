using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScripts : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float reach = 1.0f;
<<<<<<< Updated upstream

    public float damage = 1.0f;

    public int dmg;

=======
    public float damage = 1.0f;
    public int dmg;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                enemy.GetComponent<EnemyHealth>().damage(dmg);
=======
                enemy.gameObject.GetComponent<mainHealth>().damage(5);

>>>>>>> Stashed changes
            }
        }

    }
    
    // Debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, reach);
    }
    
}

