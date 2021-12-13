using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    public Animator animator;
    private GameObject sword;
    public float speed;
    public float jumped = 5.0f;
    

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();        
        sword = GameObject.Find("Sword");

        //swingSword = GetComponent<SwordScripts>().swingSword();
    }

    // Update is called once per frame
    void Update()
    { 
       move();
        //FixedUpdate();

        // if (Input.GetKeyDown("space"))
        // {
        //     playerRb.AddForce(transform.position * jumped, ForceMode.Impulse);
        //     //jump();
        // }
    }

        //float horizontalInput = Input.GetAxis("Horizontal");


    private void FixedUpdate()
    {
        Vector3 playerPos = transform.position; 
        // Basic Movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        
        transform.Translate(transform.right * horizontalInput * speed * Time.deltaTime);
        movePlayer(verticalInput, horizontalInput);
        playerRb.MovePosition(playerPos + transform.forward * verticalInput * speed * Time.deltaTime);



    }

    void movePlayer(float movingV, float movingH)
    {
        


        if (movingV != 0 || movingH != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move",false);
        }
    }

    void jump()
    {
        Debug.Log("working");
        //playerRb.AddForce(transform.position * jumped, ForceMode.Impulse);
        //playerRb.AddForce( new Vector3(0,2,0)* jumped, ForceMode.Impulse);
    }

    void move()
    {
       
        // Basic Movement
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
       // movePlayer(verticalInput, horizontalInput);

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }
}
