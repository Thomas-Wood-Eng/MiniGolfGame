using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControllerMenu : MonoBehaviour
{
    //set variables
    private Rigidbody2D rb;
    private float r1, r2;
    // Start is called before the first frame update
    void Start()
    {
        //declare rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the bal is stopped...
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            //set a random range from 1-5
            r1 = Random.Range(1, 5);
            r2 = Random.Range(1, 5);

            //the ball is now travelling that speed 
            rb.velocity = new Vector2(r1, r2);
        }
    }
}