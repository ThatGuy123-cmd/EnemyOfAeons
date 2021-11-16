using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public float boundaryX;
    // DONT NEGATIVE THIS
    public float boundaryY;
    public float boundaryZ;
    const float entryHeightZ = 10.0f; 

    Rigidbody dragonRB;

    // Start is called before the first frame update
    void Start()
    {
        dragonRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
