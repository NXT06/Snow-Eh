using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPrompt : MonoBehaviour
{
    Transform pos;

   

    private void Start()
    {
        pos = GetComponent<Transform>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = Vector3.one * Mathf.Sin(Time.deltaTime * 2);
    }
}
