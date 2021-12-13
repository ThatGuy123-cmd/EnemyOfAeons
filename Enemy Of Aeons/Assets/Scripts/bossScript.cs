using UnityEngine;
using UnityEngine.UI;

public class bossScript : MonoBehaviour
{
    //public float speed = 2.0f;
    public Rigidbody bossBody;
    public GameObject player;
    public float Currenthealth = 10;
    public float Maxhealth = 10;
    public Slider slider;
    public Animator anim;

    private CharacterController character;
    public float jumpSpeed = 8f;
    private float vSpeed = 0f;
    private bool jump = false;


    void Start()
    {
        bossBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        Currenthealth = Maxhealth;
        slider.value = CalculateHealth();
        
        anim.SetTrigger("still");
    }


    void Update()
    {
        slider.value = CalculateHealth();
        anim.SetTrigger("still");
     
        

        if (Currenthealth <= 0)
        {
            anim.SetTrigger("Death");
        }
       // Move(); 
        fallDeath();
    }
    float CalculateHealth(){
        return Currenthealth/Maxhealth;
    }

    public void damage(float damage){
        Currenthealth -= damage;
    }
    
    public void fallDeath(){
        if (transform.position.y <= -5){
            Currenthealth = 0;
        }
    }

    // public void Move()
    // {
    //     anim.SetTrigger("still");
    //     anim.SetBool("rep", false);
    //     transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    // }

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            anim.SetTrigger("fight");
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 

            other.gameObject.GetComponent<PlayerHealth>().damage(1);

            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
        }
        if(other.gameObject.CompareTag("edge")){

           //bossBody.velocity = new Vector3(-2 * speed, bossBody.velocity.y); 
               transform.Translate(0,transform.position.y+4,0);
           //bossBody.AddForce(bossBody.transform.position * 1f, ForceMode.Impulse); 
        }
    }
}
