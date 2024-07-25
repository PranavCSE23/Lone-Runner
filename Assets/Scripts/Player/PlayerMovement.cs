using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Playercontrols controls;
    float direction = 0;
    public  Rigidbody2D playerRB;
    public Animator animator; 
    public float speed = 400f; 
    public float jumpforce=5;
    public Boolean isFacingRight = true;
    static public bool isGrounded;
    public Transform groundcheck;
    public LayerMask groundLayer;
    int numberofJumps=0;
    private void Awake()
    {
        controls=new Playercontrols();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        } ;
        controls.Land.Jump.performed += ctx =>Jump();
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded= Physics2D.OverlapCircle(groundcheck.position, 0.1f,groundLayer);
        animator.SetBool("isGrounded",isGrounded);
        playerRB.velocity= new Vector2(direction *speed * Time.fixedDeltaTime,playerRB.velocity.y);
        animator.SetFloat("Speed",Mathf.Abs(direction));
        if (isFacingRight && direction <0 || !isFacingRight && direction >0)
        {
            Flip();
        }
       
        
    }
     void Flip()
        {
            isFacingRight=!isFacingRight;
            transform.localScale= new Vector2(transform.localScale.x *-1,transform.localScale.y);
        }
    void Jump()
    {
        if(isGrounded && playerRB != null)
        {
            numberofJumps=0;
            playerRB.velocity = new Vector2(playerRB.velocity.x,jumpforce);
            numberofJumps++;
            AudioManager.instance.Play("Jump");
        }
        else
        {
            if(numberofJumps==1 && playerRB != null)
            {
            playerRB.velocity = new Vector2(playerRB.velocity.x,jumpforce);
            numberofJumps++;
            }
        }
    }
}
