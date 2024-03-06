using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTest : MonoBehaviour
{

    bool lerp;

    public Vector3 smallScale;
    public Vector3 peakScale;
    public float interpolation1;
    public AnimationCurve curve1;
    Vector2 explode; 

    Vector3 endPosition;
    public float interpolation2;
    public AnimationCurve curve2;

    public GameObject snowball;
    Rigidbody2D rb; 
    public float lerpTimerPos;
    public float lerpTimerScale;
    bool canExplode;
    Vector2 startPos; 

    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endPosition = transform.position + movement;
        endPosition.x += 10;
        canExplode = true;
        startPos.x = Shovel.startPos.x;
        startPos.y = Shovel.startPos.y; 
    }

    void Update()
    {
        
            lerp = true;

        rb.AddForce(transform.up * 20);
       
        
            
            interpolation1 = curve1.Evaluate(lerpTimerScale);
            transform.localScale = Vector3.Lerp(smallScale, peakScale, interpolation1);

            lerpTimerScale += Time.deltaTime * 0.7f;
            
            



        
            
        

        if (transform.position.x > startPos.x + 8f || transform.position.y > startPos.y + 8f || transform.position.x < startPos.x - 8f || transform.position.y < startPos.y - 8
        || transform.position.x > 5 || transform.position.y > 3 || transform.position.x < -5 || transform.position.y < -3.0)
        {

            Instantiate(snowball, transform.position, transform.rotation);
           
           
            Destroy(gameObject);
            
       }

    
       

        

    }

    
    

}
