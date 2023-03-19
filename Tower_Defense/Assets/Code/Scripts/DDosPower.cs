using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDosPower : MonoBehaviour
{     
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Tower"))
        {
            Tower torre = collision.transform.root.GetComponentInChildren<Tower>();
            torre.TurnOff();
        }
    }
}
