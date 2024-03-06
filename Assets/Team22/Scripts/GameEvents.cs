using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
using UnityEngine.InputSystem.iOS;

public class GameEvents : MicrogameInputEvents
{
    // get how many snowballs are on each side/get whos the winner

    public GameObject screen1;
    public GameObject screen2;

    public float screenStopLocation = 9;

    protected override void OnTenSecondsLeft()
    {
        // executes when there are 10 seconds left in the game, potential 10 second left message
    }

    protected override void OnTimesUp()
    {
        //determine who is the winner, then call EndScreenBehaviour and pass the winning screen

        EndScreenBehaviour(screen1);
    }


    public void EndScreenBehaviour(GameObject winningScreen)
    {
        // change screen location
        winningScreen.transform.position = Vector3.zero;
    }
}
