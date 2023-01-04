using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerTimed : MonoBehaviour
{
    //set variables
    public static GameControllerTimed instance;

    public static int currHole = 0;
    public static int parScore;

    private int totalStrokes;

    public Text TimerText;
    public Text currentHoleText;

    public float TimerNumber = 240;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if you click the escape key...
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //load the main menu
            SceneManager.LoadScene("Main Menu");
        }
        //if you have not completed the course and there is time left...
        if (currHole <= 8 && TimerNumber >= 0)
        {
            //decrease the time remaining
            TimerNumber -= Time.deltaTime;
        }
        else
        {
            TimerNumber = TimerNumber;
        }
      
        //set the timer text
        //also round the number
        TimerText.text = "Time:" + Mathf.Round(TimerNumber);

        //if you run out of time
        if (TimerNumber <= 0)
        {
            //load the lose screen
            SceneManager.LoadScene("LoseTimed");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //show the hole number
            currentHoleText.text = "Current Hole: " + (currHole + 1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            currentHoleText.text = "";
        }

    }
    public void winChecker()
    {
        currHole++;
        Debug.Log(currHole);
        //Debug.Log("Winchecker");
        totalStrokes += ballController.Strokes;
        ballController.Strokes = 0;
       
        //if you complete the course and there is time left...
        if (currHole > 8 && TimerNumber >= 0)
        {
            //load the win screen
            SceneManager.LoadScene("WinTimed");
        }
    }
   
    

}
