using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using team22;

namespace team22
{
    public class GameEvents : MicrogameInputEvents
    {
        public Slider slider;

        public GameObject bearScreen;
        public GameObject beaverScreen;

        private bool timeIsUp = false;

        private bool bearWins;

        public Vector2 screenStartLocation = new Vector2(0, 8.6f);
        public Vector2 screenStopLocation = Vector2.zero;
        
        float timeElapsed;
        public float interpolateValue;
        float lerpDuration = 2.5f;

        public AnimationCurve curve1;

        [SerializeField] public AudioClip whistle;
        bool whistleBool = false;
        bool played = false;


        protected override void OnTimesUp()
        {
            timeIsUp = true;
            
            // figure out who won and instantiate respective screens
            if (slider.value < 360) // if the red side wins (Bear)
            {
                Instantiate(bearScreen, screenStartLocation, Quaternion.identity);
                bearWins = true;
            }
            if (slider.value > 360) // if blue side wins (Beaver)
            {
                Instantiate(beaverScreen, screenStartLocation, Quaternion.identity);
                bearWins = false;
            }

            if (slider.value == 360) // if there is a tie or some other state
            {
                int findWhoWonRange = Random.Range(1, 2);
                if (findWhoWonRange == 1) // bear wins
                {
                    Instantiate(bearScreen, screenStartLocation, Quaternion.identity);
                    bearWins = true;
                }
                else // beaver wins
                {
                    Instantiate(beaverScreen, screenStartLocation, Quaternion.identity);
                    bearWins = false;
                }
            }
        }

        public void Update()
        {

            if (timeIsUp) 
            {
                
                
                // determine who is the winner
                if (bearWins) // if bear wins
                {
                    // call EndScreenBehaviour and pass the winning screen
                    EndScreenBehaviour(bearScreen);
                    
                }
                if (!bearWins) // if beaver wins
                {
                    // call EndScreenBehaviour and pass the winning screen
                    EndScreenBehaviour(beaverScreen);
                    
                }
            }  

            if (whistleBool && played == false)
            {
                AudioSource.PlayClipAtPoint(whistle, transform.position, 10f);
                whistleBool = false;
                played = true;
            }

        }

        public void EndScreenBehaviour(GameObject winningScreen)
        {

            whistleBool = true;
            // if the elapsed time for the lerp is less than the duration
            if (timeElapsed < lerpDuration)
            {
                interpolateValue = curve1.Evaluate(timeElapsed / lerpDuration);

                // Update the screen's transform porition
                winningScreen.transform.position = Vector3.Lerp(screenStartLocation, screenStopLocation, interpolateValue);
                timeElapsed += Time.deltaTime;
            }
        }
    }
}
