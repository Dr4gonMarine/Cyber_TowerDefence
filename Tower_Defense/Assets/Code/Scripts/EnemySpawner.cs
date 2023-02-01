using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuracoes")]
    public int enemyCount = 10;  

    [Header("Delay")]
    [SerializeField] private float delayBtwSpawns;


    private float _spawnerTimer;
    private int _enemiesSpawned;

    private ObjectPooler _pooler;
    void Start()
    {
        _pooler = GetComponent<ObjectPooler>();
    }

    
    void Update()
    {
        _spawnerTimer -= Time.deltaTime;
        if(_spawnerTimer < 0)
        {
            _spawnerTimer = delayBtwSpawns;
            if(_enemiesSpawned < enemyCount)
            {
                _enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject newInstace = _pooler.GetInstaceFromPool();
        newInstace.transform.position = transform.position;
        newInstace.SetActive(true);
    }
}
