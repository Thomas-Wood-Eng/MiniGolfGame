using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //set variables
    public static GameController instance;

    public static int currHole = 0;
    public static int parScore;

    public Text StrokeNumber;
    public Text ParNumber;
    public Text FeedBackText;
    public Text totalScoreText;
    public Text currentHoleText;

    public static float totalStrokes;
    
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
        //if you press the escape key...
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //go to the main menu
            SceneManager.LoadScene("Main Menu");
        }
        //set the par based on the hole
        if (currHole == 0 || currHole == 1)
        {
            parScore = 2;
            ParNumber.text = "Par: " + parScore;
        }
        if (currHole == 2)
        {
            parScore = 3;
            ParNumber.text = "Par: " + parScore;
        }
        if (currHole == 3 || currHole == 4 || currHole == 5 || currHole == 6)
        {
            parScore = 4;
            ParNumber.text = "Par: " + parScore;
        }
        if (currHole == 8)
        {
            parScore = 5;
            ParNumber.text = "Par: " + parScore;
        }
        if (currHole == 7)
        {
            parScore = 6;
            ParNumber.text = "Par: " + parScore;
        }
        //if you complete the course...
        if (currHole > 8)
        {
            //load up the end screen
            SceneManager.LoadScene("WinnerRegular");
        }
        //if you hold down rgw space...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //show the total strokes
            totalScoreText.text = "Total Strokes: " + totalStrokes;
            //show the hole number
            currentHoleText.text = "Current Hole: " + (currHole + 1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            totalScoreText.text = "";
            currentHoleText.text = "";
        }
    }
    public void winChecker()
    {
        currHole++;
        //Debug.Log("Winchecker");
        //add the stokes to the total and reset the variable
        totalStrokes += ballController.Strokes;
        ballController.Strokes = 0;

        UpdateText();
    }
    public void UpdateText()
    {
        //update text
        StrokeNumber.text = "Stroke: " + ballController.Strokes;
    }
    public void Feedback()
    {
            //Debug.Log("Feeback!");
            //give feedback based on amount of strokes
            if (ballController.Strokes <= 1)
            {
                FeedBackText.text = "A Hole in 1?! Incredible!";
            }
            else if (ballController.Strokes < parScore)
            {
                Debug.Log("Under Par");
                FeedBackText.text = "Under Par! Good Job!";
            }
            else if (ballController.Strokes == parScore)
        {
            Debug.Log("Par");
            FeedBackText.text = "Par. Average.";
        }
            else if (ballController.Strokes > parScore)
        {
            Debug.Log("Over Par");
            FeedBackText.text = "Above Par? Disappointing.";
        }
        
    }

}
