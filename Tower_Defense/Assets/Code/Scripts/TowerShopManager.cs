using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShopManager : MonoBehaviour
{
    [SerializeField] GameObject towerCardPrefab;
    [SerializeField] GameObject ShopContainer;

    public List<TowerSettings> Towers;

    private void Start()
    {
        //ShopContainer.SetActive(false);
        float offset = 0f;        

        foreach (var item in Towers)
        {
            GameObject card = Instantiate(towerCardPrefab, ShopContainer.transform);            
            var shopCard = card.GetComponent<ShopCard>();
            shopCard.SetupTowerButton(item);

            //Set Location
            card.transform.localPosition = new Vector3(offset, 0f, 0f);            
            offset += card.GetComponent<RectTransform>().sizeDelta.x;
        }        
    }
}
