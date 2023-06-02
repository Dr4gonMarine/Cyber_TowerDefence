using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] TowerSettings _towerSettings;
    [SerializeField] GameObject _detailManager;
    private TowerDetailManager _detailManagerScript;

    public float Range { get => _towerSettings.Range; }
    public float FireRate { get => _towerSettings.FireRate; }
    public int SellPrice { get => _towerSettings.SellPrice; }
    public int NumDDosEffects = 0;
    public GameObject RelatedNode; 

    private void Awake()
    {
        //pegar instancia do detalhe do tower e seu script
        _detailManager = GameObject.Find("TowerDetailManager");
        _detailManagerScript = _detailManager.GetComponent<TowerDetailManager>();

        CircleCollider2D range = GetComponentInChildren<CircleCollider2D>();
        range.radius = Range;
    }


    public void OpenDetails()
    {
        _detailManagerScript.OpenDetails(this);
    }    

    public void AddDDosEffect()
    {
        NumDDosEffects++;
    }

    public void RemoveDDosEffect()
    {
        NumDDosEffects--;
    }

    //void RotateTowardsTarget()
    //{
    //    if (CurrentEnemy == null)
    //        return;        
    //}
}
