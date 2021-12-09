using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonLordMinionSpawn : MonoBehaviour
{
    public int minionCount;

    public GameObject demonlord; 
    public GameObject minionPrefab;

    private Rigidbody minionBody;
    public GameObject player;

    void Start(){
        demonlord = GameObject.Find("demonlord");
        minionBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update(){
        minionCount = GameObject.FindGameObjectsWithTag("minion").Length;

        if (minionCount == 1){
            SpawnMinionWave(2); 
        }
        
        minionMovement();
        fallDeath();
    }


    void SpawnMinionWave(int minionsToSpawn){
        Vector3 demonlordPos = new Vector3(demonlord.transform.position.x, demonlord.transform.position.y, demonlord.transform.position.z);
        Vector3 demonlordOffset1 = new Vector3(+5, 0, -6); 
        Vector3 demonlordOffset2 = new Vector3(+5, 0, 0);
        Vector3 demonlordOffset3 = new Vector3(+5, 0, -4);
        Vector3[] demonlordArray = {demonlordPos+demonlordOffset1, demonlordPos+demonlordOffset2, demonlordPos+demonlordOffset3};
        
        for(int i = 0; i < demonlordArray.Length; i++){
            Instantiate(minionPrefab, demonlordArray[i], minionPrefab.transform.rotation);
        }
    }

    void minionMovement()
    {
        Vector3 lookDirection = player.transform.position-transform.position;
        
        minionBody.AddForce(lookDirection.normalized * 1);
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

            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 

            other.gameObject.GetComponent<PlayerHealth>().damage(1);

            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            //counter +=2;
        }
    }
}