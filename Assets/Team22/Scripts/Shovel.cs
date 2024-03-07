using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using team22;

public class Shovel : MicrogameInputEvents
{
    public Vector2 movement; 
    public GameObject snowOnShovel;
    public GameObject snowBall; 
    public float snow;
    public static bool canThrow; 
    Rigidbody2D rb;
    public Transform throwPos;
    public GameObject prompt; 
    public static Vector2 startPos;

    int snowSize2;
    public static int snowSize; 

    public List<AudioClip> throwSnowClipList = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        snowOnShovel.SetActive(false);
        snowSize = 0; 
        rb = GetComponent<Rigidbody2D>();   
        prompt.SetActive(false);
    }

    private void Update()
    {
        ThrowButton();
        if (snowSize < 10)
        {
            snowOnShovel.transform.localScale = Vector3.one * (snowSize * 0.1f);
        }
        if (snowSize > 9)
        {
            prompt.SetActive(true);
        }
        else
        {
            prompt.SetActive(false);
        }
    }
    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (snowSize > 1)
        {
            snowOnShovel.SetActive(true);
        }

        
    }

    public void ThrowButton()
    {
        if (canThrow == true && snowSize > 9)
        {
           
                
                    startPos.x = transform.position.x;
                    startPos.y = transform.position.y;
                    Instantiate(snowBall, throwPos.position, transform.rotation);
                    snowSize = 0;
                    Debug.Log(startPos);
                    AudioSource.PlayClipAtPoint(throwSnowClipList[Random.Range(0, throwSnowClipList.Count)], transform.position, 10f);
                
            

            canThrow = false;
        }
    }
    
}
