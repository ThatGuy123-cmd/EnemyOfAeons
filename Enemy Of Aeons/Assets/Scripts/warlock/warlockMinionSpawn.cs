using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warlockMinionSpawn : MonoBehaviour {
   public int minionCount;

    public GameObject warlock; 
    public GameObject minionPrefab;



    void Start(){
        warlock = GameObject.Find("warlock");
    }


    void Update(){
        minionCount = GameObject.FindGameObjectsWithTag("minion").Length;

        if (minionCount == 0){
            SpawnMinionWave(3); 
        }
    }


    void SpawnMinionWave(int minionsToSpawn){
        Vector3 warlockPos = new Vector3(warlock.transform.position.x, warlock.transform.position.y, warlock.transform.position.z);
        Vector3 warlockOffset1 = new Vector3(0, 0, +10); 
        Vector3 warlockOffset2 = new Vector3(-6, 0, -3);
        Vector3 warlockOffset3 = new Vector3(+6, 0, -3);
        Vector3[] warlockArray = {warlockPos+warlockOffset1, warlockPos+warlockOffset2, warlockPos+warlockOffset3};
        
        for(int i = 0; i < warlockArray.Length; i++){
            Instantiate(minionPrefab, warlockArray[i], minionPrefab.transform.rotation);
        }
    }
}

//spawn minions in proximity to warlock
//have them move towards player 