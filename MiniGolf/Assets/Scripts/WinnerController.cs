using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerController : MonoBehaviour
{
    //set variables
    public Text WinnerText;
    public Text titleText;

    private float Number;

    public GameObject WinSound;
    public GameObject loseSound;

    private AudioSource lose;
    private AudioSource Win;

    // Start is called before the first frame update
    void Start()
    {
        //start stuff
        Win = WinSound.GetComponent<AudioSource>();
        lose = loseSound.GetComponent<AudioSource>();

        //based on the user's score, set the text to win or lose or meh.
        if (GameController.totalStrokes < 38)
        {
            Win.Play();
            titleText.text = "You Win!!!";
            WinnerText.text = "You Win! You managed to beat the 38 stroke par! You completed the course with " + GameController.totalStrokes + " strokes. Well Done! Want to play again? Just return to the main menu with the escape key.";
        }

        if (GameController.totalStrokes == 38)
        {
            titleText.text = "You are Average";
            WinnerText.text = "You were average. You managed to get the 36 stroke par! Well Done. Want to play again? Just return to the main menu with the escape key.";
        }

        if (GameController.totalStrokes > 38)
        {
            lose.Play();
            titleText.text = "You Lose!!!";
            WinnerText.text = "You Lose! You got more than the 36 stroke par! You completed the course with " + GameController.totalStrokes + " strokes. Poorly done. Want to play again? Just return to the main menu with the escape key.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //laod main menu if clicked
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
