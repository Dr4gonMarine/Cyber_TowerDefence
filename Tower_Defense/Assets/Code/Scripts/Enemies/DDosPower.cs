using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDosPower : MonoBehaviour
{               

    private void Awake()
    {
        //pegar o script do level manager
        LevelManager levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Tower"))
        {
            Tower torre = collision.GetComponentInChildren<Tower>();
            torre.AddDDosEffect();                       
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            Tower torre = collision.GetComponentInChildren<Tower>();
            torre.RemoveDDosEffect();    
        }
    }

    // private void Update(){
    //     if (transform.parent != null && !transform.parent.gameObject.activeSelf){
    //         foreach (Tower torre in levelManager.Inactive_towers)
    //         {
    //             torre.TurnOn();
    //         }
    //     }
    // }  
}
