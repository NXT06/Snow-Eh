using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public int weight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Shovel.snowSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Shovel.snowSize < 10)
        {
            Shovel.snowSize += weight;
             
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && Shovel.snowSize < 10)
        {
            Shovel2.snowSize2 += weight;

            Destroy(gameObject);
        }
    }
}
