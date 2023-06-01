using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Tower Shop Setting")]
public class TowerSettings : ScriptableObject
{
    public GameObject TowerPrefab;
    public int TowerShopCost;
    public Sprite TowerShopSprite;   
    public float FireRate;
    public float Range;
}
