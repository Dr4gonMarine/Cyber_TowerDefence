using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuracoes")]
    public int WaveEnemyCount = 10;   
    public int MaxWaves = 3;   

    [Header("Delay")]
    [SerializeField] private float delayBtwSpawns;


    private float _spawnerTimer;
    private int _enemiesSpawned;
    private int _currentWave;
    private bool _preparing = false;

    private ObjectPooler _pooler;
    void Start()
    {
        _currentWave = 1;
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
                if(!_preparing)
                    PrepareNextWave().GetAwaiter();
            }
        }
    }

    async Task PrepareNextWave()
    {
        if(_currentWave < MaxWaves)
        {
            _preparing = true;
            await Task.Delay(30000);
            _currentWave++;
            WaveEnemyCount = 10;
            _preparing = false;
        }
    }

    void SpawnEnemy()
    {
        GameObject newInstace = _pooler.GetInstaceFromPool();
        newInstace.transform.position = transform.position;
        newInstace.SetActive(true);
    }
}
