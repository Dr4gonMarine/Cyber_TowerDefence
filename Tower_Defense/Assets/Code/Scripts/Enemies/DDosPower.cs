using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDosPower : MonoBehaviour
{     
   
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Tower"))
        {
            Tower torre = collision.GetComponentInChildren<Tower>();
            torre.TurnOff();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            Tower torre = collision.GetComponentInChildren<Tower>();
            torre.TurnOn();
        }
    }
}
