using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Sprite DoorOpen;
    private SpriteRenderer door;

    void Start()
    {
        door = GetComponent<SpriteRenderer>();       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            door.sprite = DoorOpen;
            
        }        
    }
}
