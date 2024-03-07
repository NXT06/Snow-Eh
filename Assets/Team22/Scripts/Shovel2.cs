using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel2 : MonoBehaviour
{
    public Vector2 movement;
    public GameObject snowOnShovel;
    public GameObject snowBall;
    public float snow;

    Rigidbody2D rb;

    public static Vector2 startPos;

    
    public static int snowSize2;
    // Start is called before the first frame update
    void Start()
    {
        snowOnShovel.SetActive(false);
        snowSize2 = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (snowSize2 > 1)
        {
            snowOnShovel.SetActive(true);
        }

        if (snowSize2 < 10)
        {
            snowOnShovel.transform.localScale = Vector3.one * (snowSize2 * 0.1f);
        }
    }
    public void ThrowButton(bool canThrow)
    {
        if (canThrow == true)
            if (snowSize2 > 9)
            {

                startPos.x = transform.position.x;
                startPos.y = transform.position.y;
                Instantiate(snowBall, transform.position, transform.rotation);
                snowSize2 = 0;
                Debug.Log(startPos);

            }

        canThrow = false;
    }
}