using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    int Lives;
    public int CurrentWave { get; set; }

    void Start()
    {                
        CurrentWave = 1;
    }
    
    public void ReduceLives()
    {
        Lives--;
        if(Lives <= 0)
        {
            Lives = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.LogWarning("Morreu");
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
