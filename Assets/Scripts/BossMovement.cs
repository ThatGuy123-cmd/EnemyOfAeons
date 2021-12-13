using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    
    public Animator anim;
    public GameObject player;
    public float speed = 2.0f;
    public void Update(){
        anim.SetTrigger("still");
        anim.SetBool("rep", false);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
