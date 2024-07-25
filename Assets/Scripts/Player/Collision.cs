using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private float collisionforce=10;
    private Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag== "Enemy")
        {
             Vector2 collisionDirection = transform.position - collision.transform.position;
            collisionDirection.Normalize();
             rb.AddForce(collisionDirection * collisionforce, ForceMode2D.Impulse);
            Health.health --;
            if(Health.health <=0)
            {
            PlayerManager.isGameOver=true;
            AudioManager.instance.Play("Game Over");
            gameObject.SetActive(false);   
            }
            else
            {
                StartCoroutine(GetHurt());
            }
           
        }   
    }
    
        IEnumerator GetHurt()
        {
           Physics2D.IgnoreLayerCollision(7,8);
           GetComponent<Animator>().SetLayerWeight(1,1 );
           yield return new WaitForSeconds(3);
           GetComponent<Animator>().SetLayerWeight(1,0);
           Physics2D.IgnoreLayerCollision(7,8,false);
        }
    public void TakeDamage()
    {
        
            Health.health --;
            if(Health.health <=0)
            {
            PlayerManager.isGameOver=true;
            AudioManager.instance.Play("Game Over");
            gameObject.SetActive(false);   
            }
            else
            {
                StartCoroutine(GetHurt());
            } 
    }

    
}
