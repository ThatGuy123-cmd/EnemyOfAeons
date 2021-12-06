using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class DragonMovement : MonoBehaviour
{
    // Tuning
    public float flightHeight = 6.0f;
    public float speed = 5.0f;

    // Boundaries
    public float XBoundary = 10.0f;
    public float ZBoundary = 10.0f;
    
    // Components
    private Rigidbody dragonRb;
    public GameObject flamePrefab;
    
    private Vector3 hoverPosition;
    // State Checks
    public Boolean routine = true;    // Controls if flight is in action
    private Boolean vectorSet = false;  // Is route AtoB set
    private Boolean positioned = false; // Is the enemy positioned 
    private Boolean outOfBounds = false;
    // Determines the Flight route
    private Vector3[] flightVectors;

    public void Start()
    {
        // Sanitycheck
        Debug.Log("XBound: " + XBoundary + "\n-XBound: " + -XBoundary);
        // Initialise Components
        dragonRb = GetComponent<Rigidbody>();
        hoverPosition = new Vector3(0, flightHeight, 5.0f);
    }

    private void Update()
    {
        if (!outOfBounds)
        {
            //Debug.Log("Checking OOB...");
            outOfBounds = isOutOfBounds(transform.position);
        }
        if (routine)
        {
            StartCoroutine("routineHandler");
            //Debug.Log("Reached Routine IF Statement...");
        }
        //Debug.Log("Checking OOB...");

    }

    /* Moveset
     */

    IEnumerator routineHandler()
    {
        //Debug.Log("RoutineHandler: CALLED...");
        Vector3 curPos = transform.position;
        // IF OUT OF BOUNDS
        if (outOfBounds)
        {
            Debug.Log("RoutineHandler: IS OUT OF BOUNDS");
            // ?????? Performance
            // Reset Control Booleans
            if (routine)
            {
                routine = false;
            }
            if (positioned)
            {
                //Debug.Log(hoverPosition);
                transform.position = hoverPosition;
                positioned = false;
            }
            if (vectorSet)
            {
                vectorSet = false;
            }
            if (curPos.y > 1.2f)
            {
                while (!positioned)
                {
                    yield return StartCoroutine("landing");
                }
            }
            else
            {
                //Debug.LogWarning("LANDING STOPPED!");
                StopCoroutine("landing");
                positioned = false;
                yield return null;
            }
        }
        else if (routine)
        {
            //Debug.Log("RoutineHandler: FLYING");
            yield return StartCoroutine("flightLogic");
        }
        yield return new WaitForSeconds(1);
    }
    
    IEnumerator flightLogic()
    {
        // Get current position on each iteration
        Vector3 curPos = transform.position;
        // Rise if below flightheight
        if (curPos.y < flightHeight)
        {
            //Debug.Log("FlightLogic: RISING");
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
        // Reached Altitude and Route set check
        else
        {
            //Debug.Log("FlightLogic: REACHED ALTITUDE");
            if (!vectorSet)
            {  
                //Debug.Log("FlightLogic: RouteVector NOT set; SETTING...");
                flightVectors = chooseRoute();
                vectorSet = true;
            }
            // If route is set commence
            else
            {
                if (!positioned)
                {
                    //Debug.Log("FlightLogic: NOT positioned; POSITIONING...");
                    transform.position = flightVectors[0];
                    transform.LookAt(flightVectors[1]);
                    Debug.Log(flightVectors[0]);
                    spawnFlame(flightVectors[0]);
                    positioned = true;
                }
                else
                {
                    //Debug.Log("FlightLogic: TRAVELLING...,SPAWN FLAME...");
                    transform.position = Vector3.MoveTowards(curPos, flightVectors[1], 1.0f * speed * Time.deltaTime);
                    yield return null;
                }
            }
        }
        yield return null;
    }

    IEnumerator landing()
    {
        //Debug.Log("LANDING FUNCTION: ");
        Vector3 curPos = transform.position;
        if (!routine && curPos.y > 1.0f)
        {  
            //Debug.Log("LANDING FUNCTION: IS AERIAL");
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            yield return null;
        }
        else
        {
            outOfBounds = false;
            positioned = true;
            yield return null;
        }
    }

    Vector3[] chooseRoute()
    {
        int mode = Random.Range(1,5);
        Vector3[] route = new Vector3[2];
        // !-- This Needs Cleanup --
        float offset = 0.05f; // Without this the script sets the transform to cancel state
        switch (mode)
        {
            // Right to Left
            case 1:
                route[0] = new Vector3(XBoundary - offset, flightHeight, 0);
                route[1] = new Vector3(-XBoundary, flightHeight, 0);
                break;
            // Left to Right
            case 2:
                route[0] = new Vector3(-XBoundary + offset, flightHeight, 0);
                route[1] = new Vector3(XBoundary, flightHeight, 0);
                break;
            // Front to Back
            case 3:
                route[0] = new Vector3(0, flightHeight, ZBoundary - offset);
                route[1] = new Vector3(0, flightHeight, -ZBoundary);
                break;
            // Back to Front
            case 4:
                route[0] = new Vector3(0, flightHeight, -ZBoundary + offset);
                route[1] = new Vector3(0, flightHeight, ZBoundary);
                break;
        }
        return route;
    }

    Boolean isOutOfBounds(Vector3 curPos)
    {
        //Debug.Log("isOOB: " + curPos.x + "   " + curPos.z+ "\n " + XBoundary + "   " + (-XBoundary));
        if (curPos.x <= -XBoundary || curPos.x >= XBoundary)
        {
            return true;
        }
        if(curPos.z <= -ZBoundary || curPos.z >= ZBoundary)
        {
            return true;
        }
        return false;
    }
    
    void spawnFlame(Vector3 position)
    {
        Vector3 origin;
        float x = position.x;
        float z = position.z;
        if (z == 0.0f)
        {
            if (x > 0)
            {
                origin = new Vector3(0 - 1.0f, 0, 0);
            }
            else
            {
                origin = new Vector3(0 + 1.0f, 0, 0);
            }
        }
        else
        {
            if (z > 0)
            {
                origin = new Vector3(0, 0, z - 1.0f);
            }
            else
            {
                origin = new Vector3(0, 0, z + 1.0f);
            }
            
        }
        Instantiate(flamePrefab, origin, Quaternion.identity);
    }
    
}