using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MiniInstructionsControllerTimed : MonoBehaviour
{
    //declare variables
    public GameObject PlayButtonTimed;

     private Button PlayTimed;

    // Start is called before the first frame update
    void Start()
    {
        //start stuff
        PlayTimed = PlayButtonTimed.GetComponent<Button>();

       //run function if clicked
       PlayTimed.onClick.AddListener(onPlayTimed);
    }

    // Update is called once per frame
    void Update()
    {
        //load main menu if escape is pressed
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
  //load scene timed if pressed
     void onPlayTimed()
     {
         SceneManager.LoadScene("Timed");
     }

}
