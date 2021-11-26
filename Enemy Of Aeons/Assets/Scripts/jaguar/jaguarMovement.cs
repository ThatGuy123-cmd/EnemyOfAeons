using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jaguarMovement : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody jaguar;
    private GameObject playerEx;

 

    private float dist = 6;
 
     
    // Start is called before the first frame update
    void Start(){

        jaguar = GetComponent<Rigidbody>();
        playerEx = GameObject.Find("playerEx");
    
    }

    // Update is called once per frame
    void Update(){
        Vector3 lookDirection = playerEx.transform.position-transform.position;
        
        jaguar.AddForce(lookDirection.normalized * speed);

        Vector3 jump2 = new Vector3 (0,1,0);

         if(Vector3.Distance(transform.position,playerEx.transform.position) < dist)
        {
                jaguar.AddForce(lookDirection, ForceMode.Impulse);
        }
    }
}
