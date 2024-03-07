using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
using UnityEngine.Audio;

namespace team22
{

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
        public AudioMixerGroup mixer;

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









            if (transform.position.x > startPos.x + 6f || transform.position.y > startPos.y + 6f || transform.position.x < startPos.x - 6f || transform.position.y < startPos.y - 6
            || transform.position.x > 6 || transform.position.y > 4 || transform.position.x < -6 || transform.position.y < -4)
            {

                Instantiate(snowball, transform.position, transform.rotation);
                PlayClip(impactSound, transform.position, 10f);

                Destroy(gameObject);

            }

            static void PlayClip(AudioClip clip, Vector3 position, float volume = 1.0f, AudioMixerGroup group = null)
            {
                if (clip == null) return;
                GameObject gameObject = new GameObject("One shot audio");
                gameObject.transform.position = position;
                AudioSource audioSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
                if (group != null)
                    audioSource.outputAudioMixerGroup = group;
                audioSource.clip = clip;
                audioSource.spatialBlend = 1f;
                audioSource.volume = volume;
                audioSource.Play();
                Object.Destroy(gameObject, clip.length * (Time.timeScale < 0.009999999776482582 ? 0.01f : Time.timeScale));
            }




        }
    }
}
