
using UnityEngine;

public class Watercollision : MonoBehaviour
{
  private void OnCollisionEnter2D (Collision2D collision)
  {
    if (collision.transform.tag=="Water")
    {
        PlayerManager.isGameOver=true;
        AudioManager.instance.Play ("Water Over");
        gameObject.SetActive(false);
    }
  }
}
