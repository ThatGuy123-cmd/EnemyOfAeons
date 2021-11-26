using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphaMenu : MonoBehaviour
{
    // Navigational Function
    public void GoToFunction()
    {
        if (gameObject.tag == "Menu")
        {
            SceneManager.LoadScene(0);
        }else if (gameObject.tag == "Jaguar")
        {
            SceneManager.LoadScene(1);
        }
        else if (gameObject.tag == "Dragon")
        {
            SceneManager.LoadScene(2);
        }
        else if (gameObject.tag == "Warlock")
        {
            SceneManager.LoadScene(3);
        }
        else if (gameObject.tag == "Turtle")
        {
            SceneManager.LoadScene(4);
        }else if (gameObject.tag == "Demon")
        {
            SceneManager.LoadScene(5);
        }
    }
}