
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    Playercontrols controls;
    public Animator animator;
    public GameObject bullet;
    public Transform bullethole;
    
    float force =500;
    
    void Awake()
    {
        
        controls = new Playercontrols();
        controls.Enable();

        controls.Land.Shoot.performed += ctx => Fire();

    }
   
    void Fire()
    {
       if(PlayerMovement.isGrounded){
      AudioManager.instance.Play("gunfire");
       animator.SetTrigger("shoot");
       
      
       GameObject go=Instantiate(bullet , bullethole.position , bullet.transform.rotation);
       
       if(GetComponent<PlayerMovement>().isFacingRight)
       {
        Destroy(go,1f);
       go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
       
       }
       else   
       {
        Destroy(go,1f);
        go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force); 
         
       } 
       
       }
      
    }
      
}
