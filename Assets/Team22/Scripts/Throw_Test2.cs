using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Test2 : MonoBehaviour
{
    // Start is called before the first frame update


    public Vector3 smallScale;
    public Vector3 peakScale;
    public float interpolation1;
    public AnimationCurve curve1;
    Vector2 explode;

    Vector3 endPosition;
    public float interpolation2;
    public AnimationCurve curve2;

    public GameObject snowball;
    Rigidbody2D rb;
    public float lerpTimerPos;
    public float lerpTimerScale;

    public Vector2 startPos;
    public Transform shovelStart;

    Vector3 movement;

    [SerializeField] public AudioClip impactSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endPosition = transform.position + movement;
        endPosition.x += 10;

        startPos.x = Shovel2.startPos2.x;
        startPos.y = Shovel2.startPos2.y;
    }

    void Update()
    {



        rb.AddForce(transform.up * 20);



        interpolation1 = curve1.Evaluate(lerpTimerScale);
        transform.localScale = Vector3.Lerp(smallScale, peakScale, interpolation1);

        lerpTimerScale += Time.deltaTime * 0.7f;

       






        if (transform.position.x > startPos.x + 8f || transform.position.y > startPos.y + 8f || transform.position.x < startPos.x - 8f || transform.position.y < startPos.y - 8
        || transform.position.x > 5 || transform.position.y > 3 || transform.position.x < -5 || transform.position.y < -4)
        {

            Instantiate(snowball, transform.position, transform.rotation);


            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(impactSound, transform.position, 10f);

        }






    }
}
