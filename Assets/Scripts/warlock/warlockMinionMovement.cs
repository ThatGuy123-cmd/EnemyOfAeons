using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warlockMinionMovement : MonoBehaviour{


    public GameObject minionPrefab;

    private Rigidbody minionBody;
    public GameObject player;



    void Start(){
        minionBody = GetComponent<Rigidbody>();
        player = GameObject.Find("player");

    }


    void Update(){

        Vector3 lookDirection = player.transform.position-transform.position;
        
        minionBody.AddForce(lookDirection.normalized * 1);
       
    }


}

