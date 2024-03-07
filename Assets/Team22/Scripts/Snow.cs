using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;

namespace team22
{
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

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && Shovel.snowSize < 20)
            {
                Shovel.snowSize += weight;

                Destroy(gameObject);
            }
            if (collision.gameObject.CompareTag("Tag8") && Shovel2.snowSize2 < 20)
            {
                Shovel2.snowSize2 += weight;
                //Debug.Log(Shovel2.snowSize2);
                Destroy(gameObject);
            }
        }
    }
}