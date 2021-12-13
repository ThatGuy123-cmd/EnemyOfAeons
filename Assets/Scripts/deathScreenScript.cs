using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deathScreenScript : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("AlphaMenu");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("AlphaMenu");
    }

    public void quit()
    {
        Application.Quit();
    }
}
