using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using team22;
using UnityEngine.InputSystem.iOS;

public class GameEvents : MicrogameInputEvents
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnGameStart()
    {
        // Code to execute when the microgame starts
    }

    protected override void OnFifteenSecondsLeft()
    {
        // Code to execute when there are 15 seconds left in the game
    }

    protected override void OnTenSecondsLeft()
    {
        // Code to execute when there are 10 seconds left in the game
    }

    protected override void OnFiveSecondsLeft()
    {
        // Code to execute when there are 5 seconds left in the game
    }

    protected override void OnTimesUp()
    {
        // Code to execute when time runs out in the game
    }

}
