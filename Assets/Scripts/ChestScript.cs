using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{

    private Animator animator;
    private bool isOpened = false;
    [SerializeField] GameObject[] treasures;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int numberOfTreasures;
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
        if(other.gameObject.tag == "Player" && !isOpened )
        {
        
            animator.Play("ChestOpening",0);
            SpawnTreasure();
            Destroy(this.gameObject,0.5f);
        }
        
    } 

    void SpawnTreasure()
    {
        int treasure = Random.Range(0,numberOfTreasures);
        Instantiate(treasures[treasure] , spawnPoint.transform.position , spawnPoint.transform.rotation );
        isOpened = true;
    }
  
}
