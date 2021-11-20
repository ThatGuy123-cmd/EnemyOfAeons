using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonlordMovement : MonoBehaviour
{
   private float speed = 2, dist = 2;
    private Rigidbody demonlordBody;
    private GameObject player;


    // Start is called before the first frame update
    void Start(){
        demonlordBody = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update(){
        Vector3 lookDirection = player.transform.position-transform.position;
        
        demonlordBody.AddForce(lookDirection.normalized * speed);

        Vector3 jump2 = new Vector3 (0,1,0);

        if(Vector3.Distance(transform.position,player.transform.position) < dist){
            demonlordBody.AddForce(lookDirection, ForceMode.Impulse);
        }
    }
}
