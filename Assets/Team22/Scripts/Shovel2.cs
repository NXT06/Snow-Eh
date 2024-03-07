using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel2 : MonoBehaviour
{
    public Vector2 movement;
    public GameObject snowOnShovel;
    public GameObject snowBall;
    public float snow;
    public static bool canThrow; 
    Rigidbody2D rb;

    public static Vector2 startPos2;

    
    public static int snowSize2;
    // Start is called before the first frame update
    void Start()
    {
        snowOnShovel.SetActive(false);
        snowSize2 = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ThrowButton();
        if (snowSize2 < 10)
        {
            snowOnShovel.transform.localScale = Vector3.one * (snowSize2 * 0.1f);
        }
    }
    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (snowSize2 > 1)
        {
            snowOnShovel.SetActive(true);
        }

      
    }
    public void ThrowButton()
    {
        if (canThrow == true)
        {
            if (snowSize2 > 9)
            {

                startPos2.x = transform.position.x;
                startPos2.y = transform.position.y;
                Instantiate(snowBall, transform.position, transform.rotation);
                snowSize2 = 0;
                

            }
            canThrow = false;
        }

    }
}