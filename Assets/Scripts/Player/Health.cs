using UnityEngine;
using UnityEngine.UI;   

public class Health : MonoBehaviour
{
    public static int health=3;
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;

    void Awake()
    {
      health=3;
    }
    void Update()
    {
      foreach (Image img in hearts)
      {
         img.sprite = emptyheart;
      }  
      for(int i = 0; i<health; i++)
      {
        hearts[i].sprite =fullheart;
      }
    }
}
