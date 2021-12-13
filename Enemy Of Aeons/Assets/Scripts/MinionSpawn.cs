using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    public int minionCount;

    public GameObject boss; 
    public GameObject minionPrefab;

    private Rigidbody minionBody;
    public GameObject player;
    
    public int speed = 1;
    public Animator animator;
    void Start(){
        boss = GameObject.Find("demonlord");
        minionBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update(){
        minionCount = GameObject.FindGameObjectsWithTag("minion").Length;

        if (minionCount == 1){
            SpawnMinionWave(2); 
        }
        
        //minionMovement();
        Move();
        fallDeath();

        // while(speed >= 1)
        // {
        //     animator.SetTrigger("Walk Forward");
        // }
    }


    void SpawnMinionWave(int minionsToSpawn){
        Vector3 demonlordPos = new Vector3(boss.transform.position.x, boss.transform.position.y, boss.transform.position.z);
        Vector3 demonlordOffset1 = new Vector3(+5, 0, -6); 
        Vector3 demonlordOffset2 = new Vector3(+5, 0, 0);
        Vector3 demonlordOffset3 = new Vector3(+5, 0, -4);
        Vector3[] demonlordArray = {demonlordPos+demonlordOffset1, demonlordPos+demonlordOffset2, demonlordPos+demonlordOffset3};
        
        for(int i = 0; i < demonlordArray.Length; i++){
            Instantiate(minionPrefab, demonlordArray[i], minionPrefab.transform.rotation);
        }
    }

    // void minionMovement()
    // {
    //     Vector3 lookDirection = player.transform.position-transform.position;
    //     
    //     minionBody.AddForce(lookDirection.normalized * 10);
    // }
    
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);


       
    }

    void fallDeath()
    {
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }
    
    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            animator.SetTrigger("Attack 01");
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 

            other.gameObject.GetComponent<PlayerHealth>().damage(1);

            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
        }
    }
}