using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed =2f;
    int dir=1;
    public Transform rightcheck;
    public Transform leftcheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left *speed *dir *Time.deltaTime);
        if (Physics2D.Raycast (leftcheck.position,Vector2.down,2)==false )
        dir = -1;

        if (Physics2D.Raycast (rightcheck.position,Vector2.down,2)==false )
        dir = 1; 
    }
}
