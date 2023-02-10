using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerShopManager : MonoBehaviour
{
    [SerializeField] GameObject towerCardPrefab;
    [SerializeField] GameObject ShopCanvas;
    [SerializeField] GameObject ShopContainer;
    [SerializeField] TextMeshProUGUI UiMoney;
    public int Money;
    [HideInInspector] public GameObject BtnShop;

    public List<TowerSettings> Towers;

    private void Start()
    {
        SetMoney();
        ShopCanvas.SetActive(false);
        foreach (var item in Towers)
        {
            GameObject card = Instantiate(towerCardPrefab, ShopContainer.transform);            
            var shopCard = card.GetComponent<ShopCard>();
            shopCard.SetupTowerButton(item);
            shopCard.ShopManager = this;                                               
        }                    
    }

    public void SetMoney()
    {
        UiMoney.text = Money.ToString();
    }

    public void CloseShop()
    {
        ShopCanvas.SetActive(false);
    }
}
