using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHogScript : MonoBehaviour
{
    [SerializeField] float damage = 0.5f;
    private GameObject player;
    private bool isAttacking;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private GameObject Player;
    
    private Animator animator;
    
    [SerializeField] float attackSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        isAttacking = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking)     // Check if the player is in Field Of View of the Enemy
        {
          Attack();
            
        }
    }

     private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))      // Trigger Attack
        {

            audioSource.Play();
            isAttacking = true;
           
        }    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")    // Check If Collided With Player
        {
            player.GetComponent<PlayerScript>().Health -= 0.5f;     // Decrease Player Health by 0.5f
            rb.velocity = new Vector2(4,4);     // Apply Knockback to enemy
            Invoke("ResetVelocity",1f);         // Reset Enemy 
        }    
    }

   
    void ResetVelocity()    // Resets enemy 
    {
        rb.velocity = new Vector2(0,0);
    }
     private void Attack()      // Directs the enemy towards the player
     {
        transform.position = Vector3.MoveTowards( transform.position, player.transform.position, attackSpeed * Time.deltaTime);
        animator.SetBool("isAttacking",isAttacking);    
     }

    

}
