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
    Rigidbody2D rb;
    float speed = 3;
    public Transform pos; 
    
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

        if (snowSize < 10) { 
        snowOnShovel.transform.localScale = Vector3.one * (snowSize * 0.1f);
    }
    }
    
}
