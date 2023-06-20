using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public Enemy _enemyTarget;
    
    [SerializeField]
    ProjectilesSettings _projectilesSettings;

    void Update()
    {
        if(_enemyTarget != null && _enemyTarget.gameObject.activeSelf)
            MoveProjectile();
        else
            ObjectPooler.RetunToPool(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy.visible){
                enemy.TakeDamage(_projectilesSettings.Damage);
                ObjectPooler.RetunToPool(gameObject);
            }
        }
    }

    void MoveProjectile()
    {            
        transform.position = Vector3.MoveTowards(transform.position, _enemyTarget.transform.position , _projectilesSettings.MoveSpeed * Time.deltaTime);
    }
}
