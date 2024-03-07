using System.Collections;
using System.Collections.Generic;
using team22;
using UnityEngine;
using UnityEngine.UI;
public class SnowSlider : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        slider.value = Counter.snowPercent + Counter2.snowPercent2;
        Debug.Log(slider.value);
    }
}
