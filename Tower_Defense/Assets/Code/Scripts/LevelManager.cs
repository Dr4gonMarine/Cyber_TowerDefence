using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    int lives;
    [SerializeField]
    TowerShopManager shopManager;

    public int CurrentWave { get; set; }

    void Start()
    {                
        CurrentWave = 1;
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
