using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
using UnityEngine.InputSystem.iOS;

public class GameEvents : MicrogameInputEvents
{

    // get how many snowballs are on each side/get whos the winner


    protected override void OnTenSecondsLeft()
    {
        // Code to execute when there are 10 seconds left in the game
    }

    protected override void OnTimesUp()
    {
        //determine who is the winner, then call a prefab object with a behaviour script and proper end screen image, and have it drop down and maybe bounce
    }

}
