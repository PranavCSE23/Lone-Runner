 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour

{
    Transform target;
    public Transform borderCheck;
    public int enemyHp = 100;
    public Animator animator;
    public Slider enemyhealthbar;
    // private SpriteRenderer sr;
 
    // Start is called before the first frame update
    void Start()
    {
        enemyhealthbar.value = enemyHp;
        target=GameObject.FindGameObjectWithTag("Player").transform;
        // sr=GetComponent<SpriteRenderer>();
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(),GetComponent<Collider2D>());
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale= new Vector2(1.3433f , 1.3433f);
            // sr.flipX=false;
        }
        else
        {
            transform.localScale= new Vector2(-1.3433f , 1.3433f);
            // sr.flipX=false;
        }
        if (PlayerManager.isGameOver==true)
        {
        
        }
    }
    public void TakeDamage(int damageAmount)
    {
        enemyHp-=damageAmount;

        enemyhealthbar.value = enemyHp;
       
        if (enemyHp>0)
        {
           animator.SetTrigger("damage");
           
        }
        else
        {
           animator.SetTrigger("death");
           GetComponent<BoxCollider2D>().enabled=false;
           this.enabled=false;
        }
    }
    public void PlayerDamage()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Collision>().TakeDamage();
    }
}
