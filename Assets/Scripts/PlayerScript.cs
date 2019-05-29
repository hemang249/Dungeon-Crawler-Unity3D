using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed = 5f;
   
    [SerializeField] TextMeshProUGUI CoinsText;
    private Animator animator;
    private int Coins = 0;
    public float Health = 3f;
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Health <= 0)     // Check if player has died
        {
            //TODO: Add player death Screen
        }

        MovePlayer();  
    }

    void MovePlayer()       // Handles Player Movement
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

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("GoldCoin"))     // Pick Up Gold Coin when Triggered
        {
            Destroy(other.gameObject);
            Coins++;                                      
            CoinsText.text = "Coins: " + Coins.ToString();     // Update GUI
            Debug.Log(Coins);
        }    
    }
}
