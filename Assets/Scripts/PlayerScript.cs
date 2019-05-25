using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private RaycastHit hit;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
        if(Physics.Raycast(transform.position , transform.forward , hit , 2))
        {
            
        }
    }

    void MovePlayer()
    {
        float xAxis = Input.GetAxis("Horizontal") * speed;
        float yAxis = Input.GetAxis("Vertical") * speed;
        Vector3 moveX = new Vector3(xAxis,0,0);
        Vector3 moveY = new Vector3(0,yAxis,0) ;

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            transform.position += moveX *  Time.deltaTime;
            animator.SetFloat("Speed",Mathf.Abs(xAxis));
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.position += moveY * Time.deltaTime;
            animator.SetFloat("Speed",yAxis);
        }

        


    }
}
