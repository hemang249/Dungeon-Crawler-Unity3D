using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidEnemyScript : MonoBehaviour
{
    private bool isAttacking = false;
    [SerializeField] GameObject Emitter;
    [SerializeField] GameObject Orb;
    [SerializeField] AudioSource ShootAudio;
   
    // Update is called once per frame
    void Update()
    {
       if(isAttacking)
       {
          Shoot();
          ShootAudio.Play();
       } 
    }

    void Shoot()
    {
        isAttacking = false;
        GameObject projectile = Instantiate(Orb , Emitter.transform.position , Emitter.transform.rotation);
        Destroy(projectile , 4f);
        Invoke("ResetStaff",3f);
    }

    void ResetStaff()
    {
        isAttacking = true;
    }

    

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            isAttacking = true;
        }    
    }
}
