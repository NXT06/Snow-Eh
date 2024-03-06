using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Shovel : MicrogameInputEvents
{
    public Vector2 movement; 
    public GameObject snowOnShovel;
    public GameObject snowBall; 
    public float snow;
    public static Vector2 rotation; 
    Rigidbody2D rb;
    float speed = 3;
    
    public static Vector2 startPos; 
    
    public static int snowSize; 
    // Start is called before the first frame update
    void Start()
    {
        snowOnShovel.SetActive(false);
        snowSize = 2; 
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
       
        if (snowSize > 9)
        {
            
            startPos.x = transform.position.x;
            startPos.y = transform.position.y;
            Instantiate(snowBall, transform.position, transform.rotation);
            snowSize = 2;
            
        }
        

    }

    private void FixedUpdate()
    {
       rb.velocity = movement;  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (snowSize > 1)
        {
            snowOnShovel.SetActive(true);
        }

        if (snowSize < 20) { 
        snowOnShovel.transform.localScale = Vector3.one * (snowSize * 0.1f);
    }
    }
    
}
