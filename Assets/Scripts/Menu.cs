using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Menu : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject HUD;
    private Scene scene;
    
    
    //PauseMenu scripts
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                resume();
            }
            else
            {
                paused();
            }
        }

    }
    
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        HUD.SetActive(true);
    }

    public void paused()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        HUD.SetActive(false);
    }

    public void hardMode()
    {
        Debug.Log("Come back to this later");
    }

    public void quit()
    {
        SceneManager.LoadScene("AlphaMenu");
    }
  
    
    
    
    
    //Death screen scripts///
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("AlphaMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }





    ///Win Menu scripts
    
    public void NextLevel()
    {
        if (scene.buildIndex < 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else if (scene.buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    public void RandomLevel()
    {
        int rand = Random.Range(1, 3);

        SceneManager.LoadScene(rand);
    }
    
    
    
}
