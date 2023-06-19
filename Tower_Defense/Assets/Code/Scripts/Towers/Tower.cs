using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] TowerSettings _towerSettings;
    [HideInInspector] GameObject _detailManager;
    private TowerDetailManager _detailManagerScript;

    [HideInInspector]public float Range { get => _towerSettings.Range; }
    public float FireRate;
    [HideInInspector] public int SellPrice { get => _towerSettings.SellPrice; }
    public int NumDDosEffects = 0;
    [HideInInspector] public GameObject RelatedNode; 

    private void Awake()
    {
        //pegar instancia do detalhe do tower e seu script
        _detailManager = GameObject.Find("TowerDetailManager");
        _detailManagerScript = _detailManager.GetComponent<TowerDetailManager>();

        FireRate = _towerSettings.FireRate;
        CircleCollider2D range = GetComponentInChildren<CircleCollider2D>();
        range.radius = Range;
    }


    public void OpenDetails()
    {
        _detailManagerScript.OpenDetails(this);
    }    

    public void AddDDosEffect()
    {
        if(_towerSettings.TowerPrefab.name != "Vpn")
            NumDDosEffects++;
    }

    public void RemoveDDosEffect()
    {
        if(NumDDosEffects > 0)
            NumDDosEffects--;
    }

    //void RotateTowardsTarget()
    //{
    //    if (CurrentEnemy == null)
    //        return;        
    //}
}
