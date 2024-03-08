using System.Collections;
using System.Collections.Generic;
using team22;
using UnityEngine;
using UnityEngine.UI;

namespace team22
{
    public class SnowSlider : MonoBehaviour
    {
        public Slider slider;

        // Start is called before the first frame update
        void Start()
        {
            slider.maxValue = 2;
            Counter.snowPercent = 360;
            Counter2.snowPercent2 = 360;
        }

        // Update is called once per frame
        void Update()
        {
            // slider.maxValue = (Counter.snowPercent + Counter2.snowPercent2) ;
            
            slider.value = (Counter.snowPercent/Counter2.snowPercent2);
            
        }

    }
}
