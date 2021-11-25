using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Artillery : MonoBehaviour
{
    public GameObject grenadePrefab;
    public GameObject missilePrefab;
    public GameObject player;
    public float delay = 3.0f;
    private Boolean _stopSpawn;
    public float XBoundary = 5.0f;
    public float ZBoundary = 5.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("launchGrenade");
        StartCoroutine("launchMissle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float randVector(float bound)
    {
        float point = Random.Range(-bound, bound);
        return point;
    }

    /*IEnumerator manageRoutines()
    {
        yield return StartCoroutine("launchGrenade");
    }*/
    
    IEnumerator launchGrenade()
    {
        // Target1 - t1
        while (!_stopSpawn)
        {
            Vector3 target = player.transform.position;
            Vector3 t1 = new Vector3(target.x,target.y + 10.0f,target.z);
            var rotation = grenadePrefab.transform.rotation;
            Instantiate(grenadePrefab, t1,rotation);
            // Target2 - t2
            for (int i = 0; i <= Random.Range(1, 4); i++)
            {
                Vector3 t2 = new Vector3(randVector(XBoundary), 10.0f, randVector(ZBoundary));
                Instantiate(grenadePrefab, t2,rotation);
            }
            yield return new WaitForSeconds(3.0f);
        }
 
    }

    IEnumerator launchMissle()
    {
        while (!_stopSpawn)
        {
            Vector3 launchPos = new Vector3(randVector(XBoundary), 0.5f, ZBoundary);
            Instantiate(missilePrefab, launchPos, rotation: missilePrefab.transform.rotation);
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        }
    }
}
