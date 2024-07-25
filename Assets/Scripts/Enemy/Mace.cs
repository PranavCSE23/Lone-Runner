using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed=0.8f;
    public float range =3;
    float startingY;
    int dir=1;
    float startingX;
    // Start is called before the first frame update
    void Start()
    {
        startingY=transform.position.y;
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime *dir);
        if(transform.position.y <startingY ||transform.position.y>startingY+range)
        dir *=-1;
        
    }
}
