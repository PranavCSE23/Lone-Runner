using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
   void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Enemy" )
    {
         
         Destroy(collision.gameObject);
         Destroy(gameObject);
         
    }
    if(collision.tag == "zombie")
    {
      collision.GetComponent<Zombie>().TakeDamage(20); 
      Destroy(gameObject);
    }
   }
}
