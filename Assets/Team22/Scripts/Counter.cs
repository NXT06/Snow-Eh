using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;

namespace team22
{

    public class Counter : MonoBehaviour
    {
        public static float snowPercent;

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
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Tag3"))
            {
                snowPercent -= 2;
            }
            if (collision.gameObject.CompareTag("Tag4"))
            {
                snowPercent--;
            }

        }



    }
}
