using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject VictoryPanel;
    [SerializeField] GameObject DefeatPanel; 
    [SerializeField] int lives = 10;
    TowerShopManager shopManager;
    EnemySpawner enemiesSpawner;    
    [SerializeField] GameObject HpGameObject;
    HpController _hpController;

    
    public int CurrentWave { get; set; }
    public int NumberOfWaves { get; set; }

    void Start()
    {                        
        CurrentWave = 1;
        shopManager = FindObjectOfType<TowerShopManager>();
        enemiesSpawner = FindObjectOfType<EnemySpawner>();
        _hpController = HpGameObject.GetComponent<HpController>();
        _hpController.SetMaxHealth(lives);
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
