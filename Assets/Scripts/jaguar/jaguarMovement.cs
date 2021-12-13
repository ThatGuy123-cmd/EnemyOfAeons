using UnityEngine;
using UnityEngine.UI;
public class jaguarMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody jaguar;
    public GameObject player;
    public Vector3 lookDirection;
    
    public float Currenthealth = 5;
    public float Maxhealth = 1;
    
    public Slider slider;
    
    public GameObject healthBar;
    public int counter = 5;
    
    public bool death = false;
    
     
    // Start is called before the first frame update
    void Start(){
        jaguar = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
        Currenthealth = Maxhealth;
        //slider.value = CalculateHealth();
    }
    
    // Update is called once per frame
    void Update()
    {
        //slider.value = CalculateHealth();
    
        // ***  Insert to call next scene when main enemy is dead  ***
        if(Currenthealth <= 0){
            //Destroy(gameObject);
            //SceneManager.LoadScene(0);
        }
        
        Move();
        //fallDeath();
        
    }
    public void Move()
    {
        Vector3 lookDirection = player.transform.position-transform.position;
        
        jaguar.AddForce(lookDirection.normalized * speed);
    
       
    }
    
}
