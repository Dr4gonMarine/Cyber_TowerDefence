using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWallPower : MonoBehaviour
{
   //identifica torres dentro do seu circle  collider
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if(collision.CompareTag("Enemy"))
        {
            var inimigo = collision.GetComponent<Enemy>(); 
            //valida se inimigo esta visivel
            if (!inimigo.visible)
            {
               inimigo.visible = true;
            }
            inimigo.MoveSpeed = inimigo.MoveSpeed / 1.5f;
        }
    } 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var inimigo = collision.GetComponent<Enemy>();
            inimigo.MoveSpeed = inimigo.MoveSpeed * 1.5f;
        }
    }  
}
