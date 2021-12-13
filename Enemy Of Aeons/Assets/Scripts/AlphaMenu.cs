using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphaMenu : MonoBehaviour
{
    
    //using onclick methods to load static reference to scene incase order changes to avoid confusion.
    //If undesirable can uncomment dynamic reference 
    public void loadJaguar()
    {
        SceneManager.LoadScene("Jaguar");
        //SceneManager.LoadScene(0);
    }
    
    public void loadDragon()
    {
        SceneManager.LoadScene("DragonMovement");
        //SceneManager.LoadScene(1);
    }
    
    public void loadWarlock()
    {
        SceneManager.LoadScene("Warlock");
        //SceneManager.LoadScene(2);
    }
    
    public void loadTurtle()
    {
        SceneManager.LoadScene("TurtletankMovement");
        //SceneManager.LoadScene(3);
    }
    
    public void loadDemon()
    {
        SceneManager.LoadScene("Demon");
        //SceneManager.LoadScene(4);
    }
    
    public void github()
    {
        Application.OpenURL("https://github.com/Time2Rage/EnemyOfAeons/tree/dev");
    }
    
    public void quit()
    {
        Application.Quit();
    }
}