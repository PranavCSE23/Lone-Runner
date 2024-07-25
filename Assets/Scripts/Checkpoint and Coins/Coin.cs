using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if(collision.transform.tag=="Player")
      {
        PlayerManager.numberofCoins++;
        PlayerPrefs.SetInt("NumberOfCoins",PlayerManager.numberofCoins);
        AudioManager.instance.Play ("Coin");
        Destroy(gameObject);
    
      }
      
   }
}
