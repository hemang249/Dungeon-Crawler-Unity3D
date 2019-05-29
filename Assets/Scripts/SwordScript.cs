using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private bool hitPressed;
    [SerializeField] GameObject swordHolder;
    [SerializeField] float damagePerSwing;
    [SerializeField] bool isPickedUp = false;
    [SerializeField] ParticleSystem BloodParticles;
    private Animator animator;  
    [SerializeField] GameObject GoldCoin;
    private AudioSource audioSource;
    [SerializeField] int chanceOfGold = 5; // 1/5
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hitPressed = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(10,11);

        if(isPickedUp)
        {
            Physics2D.IgnoreLayerCollision(8,10);
            this.transform.localPosition = new Vector3(0,0,0);
        }
        SwingSword();
    }

    void SwingSword()
    {
        if(Input.GetKey(KeyCode.Space) && !hitPressed)
        {
            hitPressed = true;
            animator.SetBool("HitPressed",hitPressed);
            audioSource.Play();
            Invoke("ResetSword",0.4f);
        }
    }
    void ResetSword()
    {
        hitPressed = false;
        animator.SetBool("HitPressed",hitPressed);
    }

    

    void OnCollisionEnter2D(Collision2D other) 
    {
      
        if(other.gameObject.tag == "Enemy")
        {
          
            ParticleSystem bloodParticles = Instantiate(BloodParticles , other.transform.position , other.transform.rotation);
            SpawnGoldOnEnemyDeath(other);
            
            Destroy(other.gameObject,0.1f);
            Destroy(bloodParticles , 1f);
           
        }

        if(!isPickedUp && other.gameObject.CompareTag("Player"))
        {
           PickUpSword();
        }
    }

    void SpawnGoldOnEnemyDeath(Collision2D other)
    {
        int chance = Random.Range(0,chanceOfGold);

        if(chance == 1)
        {
            Instantiate(GoldCoin , other.transform.position , other.transform.rotation );
        }

    }

    void PickUpSword()
    {
        swordHolder = GameObject.FindGameObjectWithTag("SwordHolder");
        isPickedUp = true;
        this.transform.parent = swordHolder.transform;
        this.transform.localPosition = new Vector3(0,0,0);
    }
}
