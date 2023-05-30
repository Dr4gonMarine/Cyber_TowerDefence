using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    List<Enemy> _enemies;

    Enemy CurrentEnemy;
    public bool isEnable = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isEnable)
        {
            _enemies.Add(collision.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (_enemies.Contains(enemy))
                _enemies.Remove(enemy);
        }
    }   

    // Update is called once per frame
    void Update()
    {
        GetCurrentEnemyTarget();
    }   

    public Enemy  GetCurrentEnemyTarget()
    {
        if(_enemies.Count <= 0)
        {
            CurrentEnemy = null;
            return null;
        }
        CurrentEnemy = _enemies[0];
        return CurrentEnemy;
    }

    internal void TurnOn()
    {
        isEnable = false;
    }

     public void TurnOff()
    {
        isEnable = false;        
    }

    //void RotateTowardsTarget()
    //{
    //    if (CurrentEnemy == null)
    //        return;        
    //}
}
