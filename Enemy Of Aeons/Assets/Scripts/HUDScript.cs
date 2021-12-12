using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    //public Text ScoreCounterText;
    
    public int scoreCount = 0;
    
    public PlayerHealth health1;
    //public PlayerScore Counter;

    void Update()
    {
        score();
        health();
        //scoreCounter();
    }

    public void score()
    {
        scoreText.text = "Score = " + scoreCount;
        
    }
    
    public void health()
    {
        healthText.text = "Health = " + health1.currentHealth;
    }
    
    // public void scoreCounter()
    // {
    //     ScoreCounterText.text = "Bonus Score = " + Counter.timeSpentOnLevel;
    // }
    
    
}
