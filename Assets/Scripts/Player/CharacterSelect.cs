using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CharacterSelect : MonoBehaviour
{
   public GameObject[] skins;
   public int SelectedCharacter;
   public  Character[] characters;
   public Button UnlockButton;
   public TextMeshProUGUI coinsText;
   private void Awake()
   {
        SelectedCharacter= PlayerPrefs.GetInt("SelectedCharacter",0);
        foreach(GameObject player in skins)
        player.SetActive(false);
        skins[SelectedCharacter].SetActive(true);

        foreach(Character c in characters)
        {
         if(c.price==0)
              c.isUnlocked=true;
              else
              {
               c.isUnlocked=PlayerPrefs.GetInt(c.name,0)==0? false:  true; 
              }
        }
        UpdateUI();
      }
   public void changeNext()
   {
      skins[SelectedCharacter].SetActive(false);
      SelectedCharacter++;
      if(SelectedCharacter==skins.Length)
      SelectedCharacter =0;

      skins[SelectedCharacter].SetActive(true);
      if(characters[SelectedCharacter].isUnlocked)
         PlayerPrefs.SetInt("SelectedCharacter",SelectedCharacter);

      UpdateUI(); 
   }

   public void changePrevious()
   {
      skins[SelectedCharacter].SetActive(false);
      SelectedCharacter--;
      if(SelectedCharacter==-1)
      SelectedCharacter =skins.Length-1;
       
      skins[SelectedCharacter].SetActive(true);
    if(characters[SelectedCharacter].isUnlocked)
         PlayerPrefs.SetInt("SelectedCharacter",SelectedCharacter);
      UpdateUI();
   }
   public void UpdateUI()
   {
      coinsText.text = ":" + PlayerPrefs.GetInt("NumberOfCoins", 0); 
     if(characters[SelectedCharacter].isUnlocked==true)
              UnlockButton.gameObject.SetActive(false);
              else
              {
               
               UnlockButton.GetComponentInChildren<TextMeshProUGUI>().text=""+ characters[SelectedCharacter].price;
               if (PlayerPrefs.GetInt("NumberOfCoins", 0)<characters[SelectedCharacter].price)
               {
                  UnlockButton.gameObject.SetActive(true);
                  UnlockButton.interactable=false;
               }
               else
               {
                  UnlockButton.gameObject.SetActive(true);
                  UnlockButton.interactable=true;
               }
              }
   }
   public void Unlock()
   {
      int Coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
      int price =characters[SelectedCharacter].price;
      PlayerPrefs.SetInt("NumberOfCoins",Coins -price);
      PlayerPrefs.SetInt(characters[SelectedCharacter].name,1);
      PlayerPrefs.SetInt("SelectedCharacter",SelectedCharacter);
      characters[SelectedCharacter].isUnlocked=true;
      UpdateUI();
   }
}
