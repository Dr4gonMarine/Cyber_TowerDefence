using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] TowerSettings _towerSettings;
  
    
    public float Range {get => _towerSettings.Range; }
    public float FireRate {get => _towerSettings.FireRate; }
    public int NumDDosEffects = 0;

    private void Awake()
    {       
        CircleCollider2D range = GetComponentInChildren<CircleCollider2D>();
        range.radius = Range;
    }
    
 
    private void OnMouseDown()
    {
        Debug.Log("Tower Clicked");
    }
 

    public void AddDDosEffect()
    {
       NumDDosEffects++;
    }

     public void RemoveDDosEffect()
    {
        NumDDosEffects--;   
    }

    //void RotateTowardsTarget()
    //{
    //    if (CurrentEnemy == null)
    //        return;        
    //}
}
