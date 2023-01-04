using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //declare object
    public GameObject FollowMe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //follow the follow me object
        transform.position = FollowMe.transform.position;
    }
}
