using System;
using UnityEngine;

public class CoverScript : MonoBehaviour
{
    private GameObject dragon;
    private String[] safeZones = {"SafeZoneTop","SafeZoneBot","SafeZoneRight","SafeZoneLeft"};
    // Start is called before the first frame update
    void Start()
    {
        dragon = GameObject.Find("Dragon");
    }

    // Update is called once per frame
    void Update()
    {
        setCover();
    }

    int calcOrientation()
    {
        Vector3 target = dragon.transform.position;
        float z = target.z;
        float x = target.x;
        if (x == 0)
        {
            if (z > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        else if (z == 0)
        {
            if (x > 0)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        return 0;

    }

    void activateCover(GameObject safeZone)
    {
        //Debug.Log("Activate " + safeZone);
        safeZone.GetComponent<Collider>().enabled = true;
    }

    void deactivateCover(GameObject safeZone)
    {
        safeZone.GetComponent<Collider>().enabled = false;
    }

    void setCover()
    {
        int mode = calcOrientation();
        GameObject tZone;

        for (int i = 0; i < safeZones.Length; i++)
        {
            if (i != mode)
            {
                String zone = safeZones[i];
                tZone = GameObject.Find(zone);
                deactivateCover(tZone);
            }
        }
        tZone = GameObject.Find(safeZones[mode]);
        activateCover(tZone);
    }
}
