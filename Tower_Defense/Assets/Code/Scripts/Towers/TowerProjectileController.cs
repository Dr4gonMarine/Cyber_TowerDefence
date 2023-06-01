using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileController : MonoBehaviour
{    
    private Tower _tower;
    private ObjectPooler _pool;

    protected float _nextAttkTime;       
    Projectile _currentProjectileLoaded;   
    
    private void Awake()
    {
        _tower = GetComponent<Tower>();
        _pool = GetComponent<ObjectPooler>();
    }

    void Update()
    {
        if (_tower.GetCurrentEnemyTarget() != null && _tower.NumDDosEffects == 0)
            LoadProjectiles();
    }

    void LoadProjectiles()
    {
        if(Time.time > _nextAttkTime)
        {
            GameObject newInstace = _pool.GetInstaceFromPool();
            newInstace.SetActive(true);
            _currentProjectileLoaded = newInstace.GetComponent<Projectile>();
            _currentProjectileLoaded.transform.position = transform.position;
            _currentProjectileLoaded._enemyTarget = _tower.GetCurrentEnemyTarget();
            _nextAttkTime = Time.time + _tower.FireRate;
        }
    }
}
