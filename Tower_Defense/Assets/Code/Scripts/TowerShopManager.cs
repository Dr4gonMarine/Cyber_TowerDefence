using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShopManager : MonoBehaviour
{
    [SerializeField] GameObject towerCardPrefab;
    [SerializeField] GameObject ShopCanvas;
    [SerializeField] GameObject ShopContainer;
    [HideInInspector] public GameObject BtnShop;

    public List<TowerSettings> Towers;

    private void Start()
    {       
        ShopCanvas.SetActive(false);
        foreach (var item in Towers)
        {
            GameObject card = Instantiate(towerCardPrefab, ShopContainer.transform);            
            var shopCard = card.GetComponent<ShopCard>();
            shopCard.SetupTowerButton(item);
            shopCard.ShopManager = this;                                               
        }                    
    }

    public void CloseShop()
    {
        ShopCanvas.SetActive(false);
    }
}
