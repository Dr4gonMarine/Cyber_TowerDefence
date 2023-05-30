using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;    

    [HideInInspector]
    public Enemy _enemyTarget;

    public float Damage;       

    void Update()
    {
        if(_enemyTarget != null)
            MoveProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(Damage);
            ObjectPooler.RetunToPool(gameObject);
        }
    }

    void MoveProjectile()
    {            
        transform.position = Vector3.MoveTowards(transform.position, _enemyTarget.transform.position , moveSpeed * Time.deltaTime);
    }
}
