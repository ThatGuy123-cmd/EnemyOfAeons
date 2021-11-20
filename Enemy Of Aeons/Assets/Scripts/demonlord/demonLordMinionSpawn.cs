using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonLordMinionSpawn : MonoBehaviour
{
   public int minionCount;

    public GameObject demonlord; 
    public GameObject minionPrefab;



    void Start(){
        demonlord = GameObject.Find("demonlord");
    }


    void Update(){
        minionCount = GameObject.FindGameObjectsWithTag("minion").Length;

        if (minionCount == 0){
            SpawnMinionWave(3); 
        }
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
}