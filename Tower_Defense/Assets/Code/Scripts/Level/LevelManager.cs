using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject VictoryPanel;
    [SerializeField] GameObject DefeatPanel; 
    [SerializeField] GameObject TimerNextWave; 
    [SerializeField] int lives = 10;
    [SerializeField] float timeBetweenWaves = 15f;
    TowerShopManager shopManager;
    EnemySpawner enemiesSpawner;    
    [SerializeField] GameObject HpGameObject;
    HpController _hpController;

    public int CurrentWave { get; set; }
    public int MaxWaves = 3;
    public bool GameStarted { get; set; }

    private TimerControler _timerControler;
    private int _enemiesOnline = 0;
    private bool _lost = false;

    void Start()
    {     
        GameStarted = false;                     
        CurrentWave = 1;
        shopManager = FindObjectOfType<TowerShopManager>();
        enemiesSpawner = FindObjectOfType<EnemySpawner>();
        _hpController = HpGameObject.GetComponent<HpController>();
        _hpController.SetMaxHealth(lives);
        _timerControler = TimerNextWave.GetComponent<TimerControler>();
    }   

    public void ReduceLives()
    {
        lives--;
        _hpController.SetHealth(lives);
        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }
    }   
    
    public void StartGame()
    {
        GameStarted = true;        
    }

    public void GameOver()
    {
        _lost = true;
        DefeatPanel.SetActive(true);
    }

    public void EnemyConcluded()
    {
        _enemiesOnline--;
        if(_enemiesOnline <= 0 && CurrentWave == MaxWaves && !_lost)
            Victory();
        
    }

    public void OneLessEnemy()
    {
        _enemiesOnline--;               
    }

    public void EnemySpawned()
    {
        _enemiesOnline++;
    }

    public void Victory()
    {
        VictoryPanel.SetActive(true);
    }

    public void GetMoney(int income)
    {
        shopManager.Money += income;
        shopManager.SetMoney();
    }

    public void LoseMoney(int value)
    {
        GameObject authDoisFatores = GameObject.Find("AuthDoisFatores(Clone)");

        if (authDoisFatores != null)
        {
            return;
        }
        else
        {
            shopManager.Money -= value;
            shopManager.SetMoney();
        }        
    }

    public void WaveCompleted()
    {
     StartNextWaveTimer();
    }

    private void StartNextWaveTimer()
    {
        TimerNextWave.SetActive(true);        
        _timerControler.StartTimer(timeBetweenWaves);
        //TimerNextWave.SetActive(false);
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
