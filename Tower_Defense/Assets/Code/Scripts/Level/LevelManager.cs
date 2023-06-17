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

    public bool RamsomwareActive;    
    public int CurrentWave { get; set; }
    public int NumberOfWaves { get; set; }
    private TimerControler _timerControler;

    void Start()
    {      
        RamsomwareActive = false;                  
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

    public void ActivateRamsomware()
    {
        RamsomwareActive = true;
        StartCoroutine(TowersDesactivated());
    }

    private IEnumerator TowersDesactivated()
    {
        RamsomwareActive = true;
        yield return new WaitForSeconds(15f);
        RamsomwareActive = false;
    }
    void GameOver()
    {
        DefeatPanel.SetActive(true);
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
