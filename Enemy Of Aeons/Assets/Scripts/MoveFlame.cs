using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MoveFlame : MonoBehaviour
{
    // Tuning
    public float speed = 5.0f;
    public float XBound = Constants.DR_XBOUND;
    public float ZBound = Constants.DR_ZBOUND;
    private Vector3 towards;
    // Start is called before the first frame update
    void Start()
    {
        towards = -(transform.position);
        transform.LookAt(towards);
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, towards, speed * Time.deltaTime);
        // Out of Bounds Check
        if (x > XBound || x < -XBound || z > ZBound || z < -ZBound)
        {
            Destroy(gameObject);
        }
    }
}
