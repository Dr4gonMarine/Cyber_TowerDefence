using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] TowerSettings _towerSettings;
    [SerializeField] List<Enemy> _enemiesInRange;
    
    public float Range {get => _towerSettings.Range; }
    public float FireRate {get => _towerSettings.FireRate; }
    public int NumDDosEffects = 0;
    Enemy CurrentEnemy;    

    private void Awake()
    {
        CircleCollider2D range = GetComponent<CircleCollider2D>();
        range.radius = Range;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _enemiesInRange.Add(collision.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (_enemiesInRange.Contains(enemy))
                _enemiesInRange.Remove(enemy);
        }
    }   

    void Update()
    {
        GetCurrentEnemyTarget();
    }   

    public Enemy  GetCurrentEnemyTarget()
    {
        if(_enemiesInRange.Count <= 0)
        {
            CurrentEnemy = null;
            return null;
        }
        CurrentEnemy = _enemiesInRange[0];
        return CurrentEnemy;
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
