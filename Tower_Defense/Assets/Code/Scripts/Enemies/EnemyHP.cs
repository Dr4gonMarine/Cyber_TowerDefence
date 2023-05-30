using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{    
    [SerializeField] private Image healthBar;        
            
    [SerializeField] private float maxHealth = 100f;    

    public float CurrentHealth { get; set; }
   
    private Enemy _enemy;
    
    void Start()
    {        
        CurrentHealth = maxHealth;

        _enemy = GetComponent<Enemy>();
    }     

    public void ResetHealthBar()
    {
        CurrentHealth = maxHealth;
        healthBar.fillAmount = 1;
    }

    public void TakeDamage(float damageReceived)
    {
        CurrentHealth -= damageReceived;
        if(CurrentHealth <= 0)
        {
            _enemy.Die();
        }
        else
        {
            healthBar.fillAmount = (CurrentHealth / maxHealth);            
        }
    }   
}
