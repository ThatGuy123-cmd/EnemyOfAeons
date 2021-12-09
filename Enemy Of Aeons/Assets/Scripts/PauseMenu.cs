using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject HUD;
    
    // Update is called once per frame
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

    //so 
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
}
