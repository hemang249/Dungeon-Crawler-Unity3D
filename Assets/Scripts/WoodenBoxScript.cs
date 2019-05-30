using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBoxScript : MonoBehaviour
{
    [SerializeField] GameObject[] loot;
    [SerializeField] int numberOfLoots;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("PlayerSword"))
        {
            int chance = Random.Range(0,numberOfLoots);
            Instantiate(loot[chance] , transform.position , transform.rotation);
            Destroy(this.gameObject);
        }    
    }
}
