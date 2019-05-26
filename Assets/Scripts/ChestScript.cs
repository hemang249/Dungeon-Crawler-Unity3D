using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{

    private Animator animator;
    private bool isOpened = false;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player" )
        {
        
            animator.Play("ChestOpening",0);
            Destroy(this.gameObject,0.5f);
        }
        
    } 

  
}
