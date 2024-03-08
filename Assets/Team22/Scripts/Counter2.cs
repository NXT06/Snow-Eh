using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;

namespace team22
{



    public class Counter2 : MonoBehaviour
    {
        public static int snowPercent2;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Tag3"))
            {
                snowPercent2 += 2;
            }
            if (collision.gameObject.CompareTag("Tag4"))
            {
                snowPercent2++;
            }

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Tag3"))
            {
                snowPercent2 -= 2;
            }
            if (collision.gameObject.CompareTag("Tag4"))
            {
                snowPercent2--;
            }
        }



    }
}
