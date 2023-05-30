using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int lives = 10;
    TowerShopManager shopManager;
    EnemySpawner enemiesSpawner;
    
    public int CurrentWave { get; set; }
    public int NumberOfWaves { get; set; }

    void Start()
    {                        
        CurrentWave = 1;
        shopManager = FindObjectOfType<TowerShopManager>();
        enemiesSpawner = FindObjectOfType<EnemySpawner>();
    }   

    public void ReduceLives()
    {
        lives--;
        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.LogWarning("Morreu");
    }

    public void GetMoney(int income)
    {
        shopManager.Money += income;
        shopManager.SetMoney();
    }

    void WaveCompleted()
    {
      
    }

    //private void OnEnable()
    //{
    //    //Enemy.OnEndReached += ReduceLives;
    //    //Spawner.OnWaveCompleted += WaveCompleted;
    //}

    //private void OnDisable()
    //{
    //   Enemy.OnEndReached -= ReduceLives;
    //}
}
