using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetailManager : MonoBehaviour
{  
    [SerializeField] GameObject DetailCanvas;       
    LevelManager _levelManager;
    private Tower _tower;

    private void Start()
    {        
        DetailCanvas.SetActive(false);       
        _levelManager = FindObjectOfType<LevelManager>();           
    }   

    public void OpenDetails(Tower tower){
        _tower = tower;
        DetailCanvas.SetActive(true);
    }

    public void CloseDetails()
    {
        DetailCanvas.SetActive(false);
    }

    public void SellTower()
    {
        _levelManager.GetMoney(_tower.SellPrice);    
        _tower.RelatedNode.SetActive(true);   
        Destroy(_tower.gameObject);
        CloseDetails();
    }
}
