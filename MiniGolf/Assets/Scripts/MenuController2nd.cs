using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController2nd : MonoBehaviour
{
    //set variables

    public GameObject RegularButton;
    public GameObject TimedButton;

    private Button Regular;
    private Button Timed;
    

    // Start is called before the first frame update
    void Start()
    {
        //declare starts
        Regular = RegularButton.GetComponent<Button>();
        Timed = TimedButton.GetComponent<Button>();
        


        Regular.onClick.AddListener(onRegular);
        Timed.onClick.AddListener(onTimed);
      
    }

    // Update is called once per frame
    void Update()
    {
        //if you hit escape...
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //load the main menu
            SceneManager.LoadScene("Main Menu");
        }
    }
    void onRegular()
    {
        //go to regular instructions
        SceneManager.LoadScene("RegularMiniInstuctions");
    }
    void onTimed()
    {
        //go to timed instructions
        SceneManager.LoadScene("TimedMiniInstructions");
    }
   
}