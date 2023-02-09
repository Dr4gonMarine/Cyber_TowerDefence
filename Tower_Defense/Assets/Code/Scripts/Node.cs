using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    GameObject shopCanvas;

    [SerializeField]
    TowerShopManager shop;   

    public void OpenShop()
    {
        shopCanvas.SetActive(true);
        shop.BtnShop = gameObject;
    }   

}
