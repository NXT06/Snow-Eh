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
    float explode; 

    Vector3 endPosition;
    public float interpolation2;
    public AnimationCurve curve2;

    public GameObject snowball; 

    public float lerpTimerPos;
    public float lerpTimerScale;
    bool canExplode; 

    void Start()
    {
        endPosition = transform.position;
        endPosition.x += 10;
        canExplode = true; 
    }

    void Update()
    {
        
            lerp = true;
        
        
       
        
            
            interpolation1 = curve1.Evaluate(lerpTimerScale);
            transform.localScale = Vector3.Lerp(smallScale, peakScale, interpolation1);

            lerpTimerScale += Time.deltaTime * 0.7f;
            
            interpolation2 = curve2.Evaluate(lerpTimerPos);
            transform.position = Vector3.Lerp(transform.position, endPosition, interpolation2);

            lerpTimerPos += Time.deltaTime * 0.1f;

        if (canExplode)
        {
            explode = Shovel.startPos + transform.position.x;
            Debug.Log(explode);
        }

        if (explode >  4f || explode < -4f && canExplode == true)
        {

            Instantiate(snowball, transform.position, transform.rotation);
           Shovel.startPos = 0;
            canExplode = false;
            Destroy(gameObject);
            
       }

        

        

    }
}
