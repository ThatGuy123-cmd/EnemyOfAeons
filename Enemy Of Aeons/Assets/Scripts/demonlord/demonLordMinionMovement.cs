using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonLordMinionMovement : MonoBehaviour
{
    public GameObject minionPrefab;

    private Rigidbody minionBody;
    public GameObject player;

    void Start()
    {
        minionBody = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = player.transform.position-transform.position;
        
        minionBody.AddForce(lookDirection.normalized * 1);
        
    }
}
