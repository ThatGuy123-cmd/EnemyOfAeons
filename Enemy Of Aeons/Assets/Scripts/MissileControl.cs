using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    // Tuning
    public float speed = 3.0f;
    private GameObject player;
    private Vector3 target;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        homing();
    }

    void homing()
    {
        target = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, 1.0f * speed * Time.deltaTime);
    }
    
}
