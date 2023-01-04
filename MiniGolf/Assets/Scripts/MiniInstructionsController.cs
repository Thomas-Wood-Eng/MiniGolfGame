using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MiniInstructionsController : MonoBehaviour
{
    //set variables
    public GameObject PlayButton;

    private Button Play;

    // Start is called before the first frame update
    void Start()
    {
        //start things
        Play = PlayButton.GetComponent<Button>();
        
        //run function if clicked
        Play.onClick.AddListener(OnPlay);
       
    }

    // Update is called once per frame
    void Update()
    {
        //load main menu if escape button is pressed.
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    //if play button is hit...
    void OnPlay()
    {
        //load the level
        SceneManager.LoadScene("Level1");
    }
   

}
