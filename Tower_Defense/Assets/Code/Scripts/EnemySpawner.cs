using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuracoes")]
    public int WaveEnemyCount = 10;   

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
            if(_enemiesSpawned < WaveEnemyCount)
            {
                _enemiesSpawned++;
                SpawnEnemy();
            }
            else
            {
                _enemiesSpawned = 0;
                WaveEnemyCount = 0;                
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
