using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static int snowPercent; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(snowPercent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tag3"))
        {
            snowPercent += 2; 
        }
        if (collision.gameObject.CompareTag("Tag4"))
        {
            snowPercent++;
        }
        
    }
    
}
