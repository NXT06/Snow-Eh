using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPrompt : MonoBehaviour
{
    Transform pos;

    public Vector3 smallScale;
    public Vector3 peakScale;
    public float interpolation1;
    public AnimationCurve curve1;
    public float lerpTimerScale;


    private void Start()
    {
        pos = GetComponent<Transform>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        interpolation1 = curve1.Evaluate(lerpTimerScale);
        transform.localScale = Vector3.Lerp(smallScale, peakScale, interpolation1);

        lerpTimerScale += Time.deltaTime * 2f;

    }
}
