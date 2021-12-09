using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool hasPowerup;
    public GameObject powerup;
    public int powerUpDuration = 5;

    public SwordHit hit;
    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            //Destroy(gameObject);
            hasPowerup = true;
            //powerupIndicator.SetActive(true);
            hit.damage = 2.0f;
            powerup.gameObject.SetActive(true);
            StartCoroutine(PowerupCooldown(5));
            
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown(int sec)
    {
        yield return new WaitForSeconds(sec);
        hasPowerup = false;
        hit.damage = 1.0f;
        
        powerup.gameObject.SetActive(false);
    }
}
