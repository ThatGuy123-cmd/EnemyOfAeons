using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warlockMinionSpawn : MonoBehaviour {
   public int minionCount;

    public GameObject warlock; 
    public GameObject minionPrefab;
    public Vector3 jumper;
    
    public float height;
    public float force;
    private Rigidbody minionBody;
    public GameObject player;
    public float speed = 0.5f;
    
    void Start(){
        warlock = GameObject.Find("warlock");
        minionBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        jumper = new Vector3(0f, height, 0f);
        
        
    }


    void Update(){
        minionCount = GameObject.FindGameObjectsWithTag("minion").Length;

        if (minionCount == 1){
            SpawnMinionWave(2); 
        }
        
        Move();
        fallDeath();
        //ump();
    }


    void SpawnMinionWave(int minionsToSpawn){
        Vector3 warlockPos = new Vector3(warlock.transform.position.x, warlock.transform.position.y, warlock.transform.position.z);
        Vector3 warlockOffset1 = new Vector3(0, +5, +10); 
        Vector3 warlockOffset2 = new Vector3(-10, 0, 0);
        Vector3 warlockOffset3 = new Vector3(+6, +5, +10);
        Vector3[] warlockArray = {warlockPos+warlockOffset1, warlockPos+warlockOffset2, warlockPos+warlockOffset3};
        
        for(int i = 0; i < warlockArray.Length; i++){
            Instantiate(minionPrefab, warlockArray[i], minionPrefab.transform.rotation);
        }
    }
    
    public void Move()
    {
        
        Vector3 lookDirection = player.transform.position-transform.position;
        
        minionBody.AddForce(lookDirection.normalized * speed);

        

       
    }

    // public void jump()
    // {
    //     if (minionBody.transform.position.y > 7)
    //     {
    //         minionBody.AddForce(0,2,0 * 2f, ForceMode.Impulse);
    //     }
    //     else if (player.transform.position.y <= 4.03)
    //     {
    //         minionBody.AddForce(transform.position.y = 4.03);
    //     }
    // }

    void fallDeath()
    {
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

            other.gameObject.GetComponent<PlayerHealth>().damage(1);

            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("edge"))
        {
            //if (transform.position.y <= 7.0f && transform.position.y <=8.0f){
                minionBody.AddForce(jumper * force, ForceMode.Impulse);
            //}
        }
    }
}
