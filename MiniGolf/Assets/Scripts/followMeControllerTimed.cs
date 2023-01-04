using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMeControllerTimed : MonoBehaviour
{
    //set variables
    public GameObject InGamePath;
    private LineRenderer path;

    Vector3[] position = new Vector3[9];

    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        //declare starts
        rb = GetComponent<Rigidbody2D>();
        path = InGamePath.GetComponent<LineRenderer>();
        path.GetPositions(position);
    }

    // Update is called once per frame
    void Update()
    {
        //move the object after each hole
        if (GameControllerTimed.currHole == 1 && transform.position != position[1])
        {
            float delta = 0.1f;
            Vector3 next = Vector3.MoveTowards(transform.position, position[1], delta);
            transform.position = next;
        }
        if (GameControllerTimed.currHole == 2 && transform.position != position[2])
        {
            float delta = 0.1f;
            Vector3 next = Vector3.MoveTowards(transform.position, position[2], delta);
            transform.position = next;
        }
        if (GameControllerTimed.currHole == 3 && transform.position != position[3])
        {
            float delta = 0.1f;
            Vector3 next = Vector3.MoveTowards(transform.position, position[3], delta);
            transform.position = next;
        }
        if (GameControllerTimed.currHole == 4 && transform.position != position[4])
        {
            float delta = 0.1f;
            Vector3 next = Vector3.MoveTowards(transform.position, position[4], delta);
            transform.position = next;
        }
        if (GameControllerTimed.currHole == 5 && transform.position != position[5])
        {
            float delta = 0.1f;
            Vector3 next = Vector3.MoveTowards(transform.position, position[5], delta);
            transform.position = next;
        }
        if (GameControllerTimed.currHole == 6 && transform.position != position[6])
        {
            float delta = 0.1f;
            Vector3 next = Vector3.MoveTowards(transform.position, position[6], delta);
            transform.position = next;
        }
        if (GameControllerTimed.currHole == 7 && transform.position != position[7])
        {
            float delta = 0.1f;
            Vector3 next = Vector3.MoveTowards(transform.position, position[7], delta);
            transform.position = next;
        }
        if (GameControllerTimed.currHole == 8 && transform.position != position[8])
        {
            float delta = 0.1f;
            Vector3 next = Vector3.MoveTowards(transform.position, position[8], delta);
            transform.position = next;
        }
    }
}
