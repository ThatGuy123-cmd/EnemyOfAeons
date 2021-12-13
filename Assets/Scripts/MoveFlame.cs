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
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        moveDirection(startPos);
        // Out of Bounds Check
        if (x > XBound || x < -XBound || z > ZBound || z < -ZBound)
        {
            Debug.Log("Destroy...");
            Destroy(gameObject);
        }
    }

    void moveDirection(Vector3 position)
    {
        float x = position.x;
        float z = position.z;
        if (z == 0)
        {
            if (x > 0)
            {
                transform.LookAt(new Vector3(20,0,0));
            }
            else
            {
                transform.LookAt(new Vector3(-20,0,0));
            }
        }
        else
        {
            if (z > 0)
            {
                transform.LookAt(new Vector3(0,0,-20));
            }
            else
            {
                transform.LookAt(new Vector3(0,0,20));
            }

        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
