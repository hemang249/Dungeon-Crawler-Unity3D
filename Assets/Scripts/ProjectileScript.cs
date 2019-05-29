using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float attackSpeed = 10f;
    private Rigidbody2D rb;
    [SerializeField] float damage = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = new Vector2(target.transform.position.x  , target.transform.position.y) ;
   
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<PlayerScript>().Health -= damage;
            Destroy(this.gameObject);
        }    
    }
}
