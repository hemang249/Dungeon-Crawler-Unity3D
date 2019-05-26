using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHogScript : MonoBehaviour
{
    [SerializeField] float damage;
    private GameObject player;
    private bool isAttacking;
    private Animator animator;
    [SerializeField] float attackSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            
            isAttacking = true;    
        }    
    }

   

     private void Attack()
     {
        transform.position = Vector3.MoveTowards( transform.position, player.transform.position, attackSpeed * Time.deltaTime);
        animator.SetBool("isAttacking",isAttacking);    
     }
}
