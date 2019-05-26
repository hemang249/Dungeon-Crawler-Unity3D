using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private bool hitPressed;
    [SerializeField] float damagePerSwing;
    private Animator animator;
    void Start()
    {
        hitPressed = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(8,10);
        if(Input.GetKey(KeyCode.Space) && !hitPressed)
        {
            hitPressed = true;
            animator.SetBool("HitPressed",hitPressed);
            Invoke("ResetSword",0.2f);
        }
    }

    

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }    
    }
}
