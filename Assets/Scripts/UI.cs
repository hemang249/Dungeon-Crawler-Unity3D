using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] Sprite[] hearts;
    [SerializeField] Image[] HealthUI;
    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateHealthUI();
    }

    void UpdateHealthUI()        // Update UI Hearts Based on Current Health of the player
    {
        switch(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Health)
        {
            case 3f: Debug.Log("Working");
                    break;
            
            case 2.5f: Debug.Log("Hit Me"); 
                    HealthUI[2].sprite = hearts[1]; 
                     break;
            
            case 2f:  HealthUI[2].sprite = hearts[0];
                     break;

            case 1.5f: HealthUI[2].sprite = hearts[0];
                       HealthUI[1].sprite = hearts[1];
                    break;
            
            case 1f: HealthUI[2].sprite = hearts[0];
                    HealthUI[1].sprite = hearts[0];
                    break;
            
            case 0.5f: HealthUI[2].sprite = hearts[0];
                    HealthUI[1].sprite = hearts[0];
                    HealthUI[0].sprite = hearts[1];
                    break;
            
            case 0f: HealthUI[2].sprite = hearts[0];
                    HealthUI[1].sprite = hearts[0];
                    HealthUI[0].sprite = hearts[0];
                    break;

        }
    }
}
