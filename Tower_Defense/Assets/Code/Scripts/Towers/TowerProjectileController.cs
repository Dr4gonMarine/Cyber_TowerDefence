using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileController : MonoBehaviour
{
    [SerializeField] float _fireRate;
    [SerializeField] float _damage;
    [SerializeField] Tower _tower;
    [SerializeField] ObjectPooler _pool;

    protected float _nextAttkTime;       
    Projectile _currentProjectileLoaded;   

    // Update is called once per frame
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
            _nextAttkTime = Time.time + _fireRate;
        }
    }
}
