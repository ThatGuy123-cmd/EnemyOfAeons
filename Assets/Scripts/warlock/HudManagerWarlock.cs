using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HudManagerWarlock : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    public TextMeshProUGUI scoreText;

    public Canvas HUD;
    public GameObject PAUSE;

    //private demonlordHealth lord = new demonlordHealth();

    public bool Paused = false;
    void Start()
    {
        //score = lord.counter;
        scoreText.text = "Score: " + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Paused)
            {
                Resume();
            }
            else{ 
                Pause();
            }
        }
    }

    public void Resume()
    {
        // PAUSE.enabled = true;
        HUD.enabled = true;
            
        //HUD.GetComponent<Canvas>().enabled = false;
        //PAUSE.GetComponent<>().enabled = true;
        PAUSE.SetActive(false);
            
        Time.timeScale = 1;

        Paused = false;
        
    }

    public void Pause()
    {
        // PAUSE.enabled = true;
        HUD.enabled = false;
            
        //HUD.GetComponent<Canvas>().enabled = false;
        //PAUSE.GetComponent<>().enabled = true;
        PAUSE.SetActive(true);

        Time.timeScale = 0;

        Paused = true;
    }

    public void Difficulty()
    {
        Debug.Log("Difficulty");
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }
}
