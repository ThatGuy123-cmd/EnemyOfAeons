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

    // Status
    private Boolean inFlight = false;
    private Vector3 hover;
    private Vector3 grounded;

    private Rigidbody dragonRb;

    public void Start()
    {
        // Initialise Components
        dragonRb = GetComponent<Rigidbody>();
        hover = new Vector3(5.0f, flightHeight, 0.0f);
        grounded = new Vector3(5.0f, 0.5f, 0.0f);
    }

    private void Update()
    {
        // IF outOfBounds
        if (outOfBounds())
        {
            transform.position = hover;
        }
        // IF flightHeight
        else if (checkFlightHeight())
        {
            inFlight = true;
        }
        // Rise
        else if (!inFlight && !checkFlightHeight())
        {
            transform.position = Vector3.MoveTowards(transform.position, hover, 1.0f * speed * Time.deltaTime);
        }
        // Land
        else if (!inFlight && checkFlightHeight())
        {
            transform.position = Vector3.MoveTowards(transform.position, grounded, 1.0f * speed * Time.deltaTime);
        }
        // Across
        else if (inFlight && checkFlightHeight())
        {
            
        }
    }

    public Boolean outOfBounds()
    {
        if (transform.position.x > XBoundary || transform.position.x < -XBoundary)
        {
            return true;
        }
        if (transform.position.z > ZBoundary || transform.position.z < -ZBoundary)
        {
            return true;
        }
        return false;
    }

    public Boolean checkFlightHeight()
    {
        if (transform.position.y >= flightHeight)
        {
            return true;
        }

        return false;
    }
    

    
}