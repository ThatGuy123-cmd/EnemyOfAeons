using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float timeSpentOnLevel = 600;
    public float hitsGivenButNotRecieved; //Coming back to this later
    public float difficulty = 1.5f;
    public float tempScore = 0;
    public float overallScore = 0;

    public String[] bossNames = {"Jaguar", "Dragon", "Warlock", "TurtleTank", "Demonlord"};

    void Update()
    {
        //Timer counts down a score bonus which incentivises player to complete stage faster 
        timeSpentOnLevel -= Time.deltaTime;

        //Score calc 
        overallScore += (difficulty * tempScore) + timeSpentOnLevel;

    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        //initalising array of bosses for modularity and assigning values if boss or minion has been hit
        for (int i = 0; i >= bossNames.Length; i++)
        {
            if (other.gameObject.CompareTag(bossNames[i]))
            {
                tempScore += 3;
            }
            else if(other.gameObject.CompareTag("minions"))
            {
                tempScore += 1;
            }
        }
    }
}
