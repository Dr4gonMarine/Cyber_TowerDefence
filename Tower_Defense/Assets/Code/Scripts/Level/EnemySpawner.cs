using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    #region Propriedades
    [SerializeField] private LevelManager _levelManager;

    [Header("Configuracoes")]
    public int WaveEnemyCount = 10;       
    [Header("Delay")]
    [SerializeField] private float delayBtwSpawns;


    private float _spawnerTimer;
    private int _enemiesSpawned;
    private bool _preparing = false;
    private string _lastSpawned;        
    private ObjectPooler[] _pooler;

    #endregion
    void Start()
    {        
        _pooler = GetComponents<ObjectPooler>();               
    }

    
    void Update()
    {
        if(_levelManager.GameStarted){
            _spawnerTimer -= Time.deltaTime;
            if(_spawnerTimer < 0)
            {
                _spawnerTimer = delayBtwSpawns;
                if(_enemiesSpawned < WaveEnemyCount)
                {    
                    _levelManager.EnemySpawned();
                    _enemiesSpawned++;                           
                    switch(SceneManager.GetActiveScene().name){
                        case "Fase_1":
                            SpawnerScene1();
                            break;
                        case "Fase_2":
                            SpawnerScene2();
                            break;
                        case "Fase_3":
                            SpawnerScene3();
                            break;
                        case "Fase_4":
                            SpawnerScene4();
                            break;
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
    }

    private void SpawnerScene1(){
        switch(_levelManager.CurrentWave){
            case 1:
                SpawnEnemy(0);
                break;

            case 2:
                if(_lastSpawned == "CavaloTroia")
                    SpawnEnemy(0);
                else{                   
                    SpawnEnemy(Random.Range(0, _pooler.Length));
                    }
                break;

            case 3:                
                SpawnEnemy(Random.Range(0, _pooler.Length));
                break;            
        }
        
    }
     private void SpawnerScene2(){
          switch(_levelManager.CurrentWave){
            case 1:
                SpawnEnemy(0);
                break;

            case 2:
                if(_lastSpawned == "Spam")
                    SpawnEnemy(0);
                else{       
                    int index = Random.Range(0, _pooler.Length);      
                    if (index == 0)
                        SpawnEnemy(index);
                    else
                        StartCoroutine(SpawnEnemiesWithDelay());
                    }                                       
                break;
                
            case 3:                
                SpawnEnemy(Random.Range(0, _pooler.Length));
                break;            
        }
    }
     private void SpawnerScene3(){

         switch(_levelManager.CurrentWave){
            case 1:
                StartCoroutine(SpawnEnemiesWithDelay(0));
                break;

            case 2:
                if(_lastSpawned == "DDos")
                    StartCoroutine(SpawnEnemiesWithDelay(0));
                else{       
                    int index = Random.Range(0, 1);      
                    if (index == 0)
                        StartCoroutine(SpawnEnemiesWithDelay(0));
                    else
                        SpawnEnemy(index);
                    }                                       
                break;
                
            case 3:                
                SpawnEnemy(Random.Range(0, _pooler.Length));
                break;            
        }     
    }

    private void SpawnerScene4()
    {
        int index = Random.Range(0, _pooler.Length); 
        if (index == 0)
            StartCoroutine(SpawnEnemiesWithDelay(0));
        else
            SpawnEnemy(index);
    }

    private IEnumerator SpawnEnemiesWithDelay(int enemyIndex = 1)
    {
        _levelManager.OneLessEnemy();
        int groupSize = Random.Range(1, 5);
        for (int i = 0; i < groupSize; i++)
        {
            _levelManager.EnemySpawned();
            SpawnEnemy(enemyIndex);
            yield return new WaitForSeconds(0.7f);
        }
    }

    async Task PrepareNextWave()
    {
        if(_levelManager.CurrentWave < _levelManager.MaxWaves)
        {
            _preparing = true;
            _levelManager.WaveCompleted(); 
            await Task.Delay(15000);
            _levelManager.CurrentWave++;
            WaveEnemyCount = 10;
            _preparing = false;
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
