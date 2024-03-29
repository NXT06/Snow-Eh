using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
using UnityEngine.Audio;

namespace team22
{
    public class Shovel2 : MicrogameInputEvents
    {
        public Vector2 movement;
        public GameObject snowOnShovel;
        public GameObject snowBall;
        public float snow;
        public static bool canThrow;
        Rigidbody2D rb;
        public Transform throwPos;
        public GameObject prompt;
        public static Vector2 startPos2;
        public AudioMixerGroup mixer;

        public static int snowSize2;

        public List<AudioClip> throwSnowClipList = new List<AudioClip>();

        // Start is called before the first frame update
        void Start()
        {
            snowOnShovel.SetActive(false);
            snowSize2 = 0;
            rb = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            ThrowButton();
            if (snowSize2 <= 20)
            {
                snowOnShovel.transform.localScale = Vector3.one * (snowSize2 * 0.05f);
            }
            if (snowSize2 > 19)
            {
                prompt.SetActive(true);
            }
            else
            {
                prompt.SetActive(false);
            }
        }
        // Update is called once per frame

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (snowSize2 > 1)
            {
                snowOnShovel.SetActive(true);
            }


        }
        public void ThrowButton()
        {
            if (canThrow == true)
            {

                startPos2.x = transform.position.x;
                startPos2.y = transform.position.y;
                Instantiate(snowBall, throwPos.position, transform.rotation);
                snowSize2 = 0; 
                PlayClip(throwSnowClipList[Random.Range(0, throwSnowClipList.Count)], transform.position, 10f, mixer);
               // AudioSource.PlayClipAtPoint(throwSnowClipList[Random.Range(0, throwSnowClipList.Count)], transform.position, 10f);



                canThrow = false;
            }

        }
        public static void PlayClip(AudioClip clip, Vector3 position, float volume = 1.0f, AudioMixerGroup group = null)
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