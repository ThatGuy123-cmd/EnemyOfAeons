using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleScript : MonoBehaviour
{
    public GameObject shield;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        shield = GameObject.Find("EnergyShield");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        raiseShield();
    }

    public void raiseShield()
    {
        if (player.transform.position.z > 3.0f)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }
}
