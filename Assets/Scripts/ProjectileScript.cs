using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float attackSpeed = 10f;
    private Rigidbody2D rb;
    [SerializeField] float damage = 1f;
    private Vector3 targetVector;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        targetVector = new Vector3(target.transform.position.x , target.transform.position.y , target.transform.position.z);
        
   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position , targetVector , attackSpeed * Time.deltaTime   );
        if(transform.position == targetVector)
        {
            Destroy(this.gameObject);
        }
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
