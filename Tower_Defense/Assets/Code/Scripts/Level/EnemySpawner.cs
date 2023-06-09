using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;

    [Header("Configuracoes")]
    public int WaveEnemyCount = 10;   
    public int MaxWaves = 3;   

    [Header("Delay")]
    [SerializeField] private float delayBtwSpawns;


    private float _spawnerTimer;
    private int _enemiesSpawned;
    private int _currentWave;
    private bool _preparing = false;
    private string _lastSpawned;

    private ObjectPooler[] _pooler;
    void Start()
    {
        _currentWave = 1;
        _pooler = GetComponents<ObjectPooler>();        
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
                //evita de spawnar 2 vezes seguidas o DDos
                if(_lastSpawned == "DDos")
                    SpawnEnemy(0);
                else{
                    int index = Random.Range(0, _pooler.Length);
                    SpawnEnemy(index);
                }                    
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
        }else{
            _levelManager.Victory();
            Debug.Log("Fim de jogo");
        }
    }

    void SpawnEnemy(int index)
    {     
        _lastSpawned = _pooler[index].poolName;                        
        GameObject newInstace = _pooler[index].GetInstaceFromPool();
        newInstace.transform.position = transform.position;
        newInstace.SetActive(true);
    }
}
