using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    List<Enemy> _enemies;

    Enemy CurrentEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
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

    public void TurnOff()
    {
        _enemies.Clear();
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

    //void RotateTowardsTarget()
    //{
    //    if (CurrentEnemy == null)
    //        return;        
    //}
}
