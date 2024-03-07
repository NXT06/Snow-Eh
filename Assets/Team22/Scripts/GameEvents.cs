using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
//using UnityEngine.InputSystem.iOS;


namespace team22
{
    public class GameEvents : MicrogameInputEvents
    {
        // get how many snowballs are on each side/get whos the winner

        public GameObject screen1;
        public GameObject screen2;

        private bool timeIsUp = false;

        public Vector2 screenStartLocation = new Vector2(0, 8.6f);
        public float screenStopLocation = 9;

        protected override void OnTimesUp()
        {
            timeIsUp = true;
            //Instantiate(, screenStartLocation, Quaternion.identity);
        }

        public void Update()
        {
            if (timeIsUp) 
            {
                //determine who is the winner, then call EndScreenBehaviour and pass the winning screen
                EndScreenBehaviour(screen1);
            }  
        }


        public void EndScreenBehaviour(GameObject winningScreen)
        {
            // change screen location
            winningScreen.transform.position = Vector3.zero;
        }
    }
}
