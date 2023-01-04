using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    //set varibales

    public GameObject StartButton;
    public GameObject ControlsButton;
    public GameObject QuitButton;

    private Button start;
    private Button controls;
    private Button quit;

    // Start is called before the first frame update
    void Start()
    {
       //declare starts
        start = StartButton.GetComponent<Button>();
        controls = ControlsButton.GetComponent<Button>();
        quit = QuitButton.GetComponent<Button>();

        //if button is pushed run certainn functions
        start.onClick.AddListener(onStart);
        controls.onClick.AddListener(onControls);
        quit.onClick.AddListener(onQuit);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onStart()
    {
        //load 2nd menu
        SceneManager.LoadScene("2nd Menu");
    }
    void onControls()
    {
        //load controls
        SceneManager.LoadScene("Controls");
    }
    void onQuit()
    {
        //quit the application
        Application.Quit();
    }
}