using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerTimedController : MonoBehaviour
{
    //set variables
    public Text WinnerText;
    private float Number;
    // Start is called before the first frame update
    void Start()
    {
        //set the timer number to a variable in this function so we can round it
        GameControllerTimed.instance.TimerNumber = Number;
        //round it
        Mathf.Round(Number);
        //set the text with the amount of time remaining
        WinnerText.text = "You Win! You managed to beat the 5 Minute Time! You completed the course with " + Number + " seconds remaining. Well Done! Want to play again? Just return to the main menu with the escape key.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
