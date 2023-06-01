using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileController : MonoBehaviour
{
    private Tower _tower;
    private ObjectPooler _pool;

    Enemy CurrentEnemy;
    [SerializeField] List<Enemy> _enemiesInRange;

    protected float _nextAttkTime;
    Projectile _currentProjectileLoaded;

    private void Awake()
    {
        _tower = GetComponentInParent<Tower>();
        _pool = GetComponent<ObjectPooler>();
    }
    void Update()
    {
        if (GetCurrentEnemyTarget() != null && _tower.NumDDosEffects == 0)
            LoadProjectiles();
    }

    public Enemy GetCurrentEnemyTarget()
    {
        if (_enemiesInRange.Count <= 0)
        {
            CurrentEnemy = null;
            return null;
        }
        CurrentEnemy = _enemiesInRange[0];
        return CurrentEnemy;
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

    void LoadProjectiles()
    {
        if (Time.time > _nextAttkTime)
        {
            GameObject newInstace = _pool.GetInstaceFromPool();
            newInstace.SetActive(true);
            _currentProjectileLoaded = newInstace.GetComponent<Projectile>();
            _currentProjectileLoaded.transform.position = transform.position;
            _currentProjectileLoaded._enemyTarget = GetCurrentEnemyTarget();
            _nextAttkTime = Time.time + _tower.FireRate;
        }
    }
}
