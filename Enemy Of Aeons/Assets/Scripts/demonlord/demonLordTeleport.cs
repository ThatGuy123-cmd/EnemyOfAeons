using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonLordTeleport : MonoBehaviour{
    private float spawnRangeX = 10, spawnRangeZ = 15;
    int interval = 20, nextTime =10; 

    
    void Start(){
    }

    void Update(){
        if (Time.time >= nextTime) {
            spawnManager();
            nextTime += interval; 
        }
    }   

    void spawnManager(){
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnRangeZ, spawnRangeZ);

        transform.position = new Vector3(xPos, 0, zPos);
    }
}
