using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jaguarMovement : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody jaguar;
    private GameObject player;
    private Vector3 lookDirection;
    private float dist = 6;
 
     
    // Start is called before the first frame update
    void Start(){

        jaguar = GetComponent<Rigidbody>();
        player = GameObject.Find("playerEx");
    
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = player.transform.position-transform.position;
        
        jaguar.AddForce(lookDirection.normalized * speed);
        
        if(Vector3.Distance(transform.position,player.transform.position) == dist){
            jaguar.AddForce(lookDirection, ForceMode.Impulse);
        }

        //Vector3 jump2 = new Vector3 (0,1,0);
        //movement(lookDirection);
    }
    
   
}
