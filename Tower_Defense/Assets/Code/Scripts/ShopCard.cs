using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    [SerializeField] Image towerImage;
    [SerializeField] TextMeshProUGUI towerCost;

   public TowerSettings TowerLoaded { get; set; }

    public void SetupTowerButton(TowerSettings towerSettings)
    {
        TowerLoaded = towerSettings;
        towerImage.sprite = towerSettings.TowerShopSprite;
        towerCost.text = towerSettings.TowerShopCost.ToString();
    }

    public void PlaceTurret()
    {
        
    }
}
