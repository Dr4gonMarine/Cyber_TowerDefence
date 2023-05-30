using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    [SerializeField] Image towerImage;
    [SerializeField] TextMeshProUGUI towerCost;

    public TowerShopManager ShopManager { get; set; }

    public TowerSettings TowerLoaded { get; set; }
    GameObject pasta;


    private void Awake()
    {
        pasta = GameObject.Find("----Towers----");
    }

    public void SetupTowerButton(TowerSettings towerSettings)
    {
        TowerLoaded = towerSettings;        
        towerImage.sprite = towerSettings.TowerShopSprite;
        towerCost.text = towerSettings.TowerShopCost.ToString();
    }

    public void PlaceTurret()
    {
        if(ShopManager.Money >= TowerLoaded.TowerShopCost)
        {
            ShopManager.Money -= TowerLoaded.TowerShopCost;
            ShopManager.SetMoney();
            Instantiate(TowerLoaded.TowerPrefab, ShopManager.BtnShop.transform.position, Quaternion.identity, pasta.transform);
            ShopManager.BtnShop.SetActive(false);
            ShopManager.CloseShop();
        }
    }
}
