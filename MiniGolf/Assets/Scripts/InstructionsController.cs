using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InstructionsController : MonoBehaviour
{
    //set variables
    public GameObject MainMenuButton;

    private Button MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        //set starts
        MainMenu = MainMenuButton.GetComponent<Button>();
    //if you click the main menu button run the main menu function
        MainMenu.onClick.AddListener(onMainMenu);
        
    }

    // Update is called once per frame
    void Update()
    {
        //load the main menu if you hit escape
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    void onMainMenu()
    {
        //load the main menu
        SceneManager.LoadScene("Main Menu");
    }
    
}