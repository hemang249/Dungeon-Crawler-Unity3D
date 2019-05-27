using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHogScript : MonoBehaviour
{
    [SerializeField] float damage = 0.5f;
    private GameObject player;
    private bool isAttacking;
    private AudioSource audioSource;
    private GameObject Player;
    
    private Animator animator;
    
    [SerializeField] float attackSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        isAttacking = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking)
        {
           
            Attack();
            
        }
    }

     private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {

            audioSource.Play();
            isAttacking = true;
           
        }    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerScript>().Health -= 0.5f;
            transform.position += new Vector3(0,1,0) * 3 ;
            
        }    
    }

   

     private void Attack()
     {
        transform.position = Vector3.MoveTowards( transform.position, player.transform.position, attackSpeed * Time.deltaTime);
        animator.SetBool("isAttacking",isAttacking);    
     }

    

}
