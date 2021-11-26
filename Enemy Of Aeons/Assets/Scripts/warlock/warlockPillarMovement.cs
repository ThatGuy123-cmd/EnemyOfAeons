using System.Security.AccessControl;
using System.Transactions;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warlockPillarMovement : MonoBehaviour {

    
    public GameObject warlock; 
    public float rotationSpeed = 20f;
    public GameObject pillarPrefab;

    public int objs;


    void Start(){
       warlock = GameObject.Find("warlock");
    }


    void Update(){
        transform.RotateAround(warlock.transform.position, new Vector3(0,1,0), rotationSpeed * Time.deltaTime);

        objs = GameObject.FindGameObjectsWithTag("pillar").Length;

        if(objs == 1){
            SpawnPillars(9);
        }
    }

    void SpawnPillars(int pillarsToSpawn){
        StartCoroutine(pillarSpawnManager(pillarsToSpawn));
    }



  
    public IEnumerator pillarSpawnManager(int pillarsToSpawn){

        Vector3 warlockPos = new Vector3(warlock.transform.position.x, warlock.transform.position.y, warlock.transform.position.z);
        Vector3 warlockOffset = new Vector3(0, +1, +2);
        
        for(int i = 0; i < pillarsToSpawn; i++){
            Instantiate(pillarPrefab,warlockPos+warlockOffset, transform.rotation);
            yield return new WaitForSeconds(2.0f);
        }//new Vector3(7,1,11)
    }
}
