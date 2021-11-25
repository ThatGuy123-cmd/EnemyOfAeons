using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class DragonMovement : MonoBehaviour
{
    // Tuning
    public float flightHeight = 10.0f;
    public float speed = 5.0f;

    // Boundaries
    public float XBoundary = 6.0f;
    public float ZBoundary = 6.0f;

    private Rigidbody dragonRb;
    // State Checks
    private Boolean routine = false;    // Controls if flight is in action
    private Boolean vectorSet = false;  // Is route AtoB set
    private Boolean positioned = false; // Is the enemy positioned 
    // Determines the Flight route
    private Vector3[] flightVectors;

    public void Start()
    {
        // Initialise Components
        dragonRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
    }

    /* Moveset
     1.1. Determine current Position
     1.2. Check if outOfBounds
     1.3. If routine is started and not in Flight - Rise to flightHeight
     1.4.If Routine is finished and not landed (flightHeight) - land
     -----
     2.1 If routine is started but the route is not set - set new route and set route true
     */
    IEnumerator flightLogic()
    {
        // Get current position on each iteration
        Vector3 curPos = transform.position;
        // CHECK OUT OF BOUNDS
        if (outOfBounds(curPos))
        {
            routine = false;
            vectorSet = false;
        }
        // Routine started & not in flight
        if (routine && curPos.y < 9)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        // Routine finished & in flight
        else if (!routine && curPos.y > 9)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        // Route set check
        if (routine && !vectorSet)
        {
            flightVectors = chooseRoute();
            vectorSet = true;
        }
        // If route is set commence
        else
        {
            if (!positioned)
            {
                transform.position = flightVectors[0];
                positioned = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(curPos, flightVectors[1], 1.0f * speed * Time.deltaTime);    
            }
        }

        yield return null;
    }

    Vector3[] chooseRoute()
    {
        int mode = Random.Range(1,5);
        Vector3[] route = new Vector3[2];
        switch (mode)
        {
            case 1:
                route[0] = new Vector3(XBoundary, 0, 0);
                route[1] = new Vector3(-XBoundary, 0, 0);
                break;
            case 2:
                route[0] = new Vector3(-XBoundary, 0, 0);
                route[1] = new Vector3(XBoundary, 0, 0);
                break;
            case 3:
                route[0] = new Vector3(0, 0, ZBoundary);
                route[1] = new Vector3(0, 0, -ZBoundary);
                break;
            case 4:
                route[0] = new Vector3(0, 0, -ZBoundary);
                route[1] = new Vector3(0, 0, ZBoundary);
                break;
        }
        return route;
    }

    Boolean outOfBounds(Vector3 curPos)
    {
        if (curPos.x < -XBoundary || curPos.x > XBoundary)
        {
            return true;
        }
        else if(curPos.z < -ZBoundary || curPos.z > ZBoundary)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}