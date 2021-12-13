using System;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{

    public GameObject flame;
    public float speed = 5.0f;

    private Boolean active;
    public int mode;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            moveFlame();
        }
    }



    private void moveFlame()
    {
        switch (mode)
        {
            case 1:
                flame.transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
            case 2:
                flame.transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            case 3:
                flame.transform.Translate(Vector3.back * speed * Time.deltaTime);
                break;
            case 4:
                flame.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
        }
    }

    public void destroyFlame(Boolean condition)
    {
        if (condition)
        {
            Destroy(flame);
            active = false;
        }
    }
}
