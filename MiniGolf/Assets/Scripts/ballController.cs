using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ballController : MonoBehaviour
{
   //set variables
    private Rigidbody2D rb;

    private float initialX, initialY;
    private float finalX, finalY;
    private float dx, dy;
    private float slowTime;

    private LineRenderer line;

    private Vector2 direction;

    private Vector3 finalPosition;
    private Vector3 positionOne, positionTwo;

    private Camera camera;

    public float swingForce;

    public GameObject hole;
    public GameObject lineObject;
    public GameObject Transformer;
    public GameObject FakeTransporter;
    public GameObject PuttSound;
    public GameObject holeInSound;
    public GameObject splooshSound;

    private AudioSource Putt;
    private AudioSource HoleIn;
    private AudioSource Sploosh;

    public static int Strokes = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //define the sounds, line and camera
        Putt = PuttSound.GetComponent<AudioSource>();
        HoleIn = holeInSound.GetComponent<AudioSource>();
        Sploosh = splooshSound.GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();

        camera = Camera.main;

        line = lineObject.GetComponent<LineRenderer>();
        line.alignment = LineAlignment.TransformZ;
        line.widthMultiplier = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        //if the ball is going slow...
       if (rb.velocity.x < 0.5 ||  rb.velocity.x > -0.5 && rb.velocity.y < 0.5 || rb.velocity.y > -0.5 && rb.velocity.x != 0 && rb.velocity.y != 0)
        {
            //start counting up a variable called slowTime
            slowTime += Time.deltaTime;
            //Debug.Log(slowTime);
            
            //if slowtime is greter than or equal to 2...
            if (slowTime >= 2)
            {
                //stop the ball
                rb.velocity = new Vector2(0f, 0f);
            }
        }
       //if the ball speeds up
        if (rb.velocity.x > 0.5 || rb.velocity.x < -0.5 && rb.velocity.y > 0.5 || rb.velocity.y < -0.5)
        {
            //put slowtime to 0
            slowTime = 0;
            //Debug.Log("RESET");
        }
        //if the ball stops 
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            //set slowtime to 0
            slowTime = 0;
           // Debug.Log("RESET b/c 0");
        }
    }
    
    //when the mouse is pressed down...
    private void OnMouseDown()
    {
        //make the line
        lineObject.SetActive(true);

        //set the line position
        initialX = transform.position.x; //
        initialY = transform.position.y;//

        positionOne = new Vector3(initialX, initialY,0);//
        line.SetPosition(0, positionOne);//
        ////////////////////////////////////////////////
    }
    //if the mouse is raised...
    private void OnMouseUp()
    {
        //and if the ball is not moving...
        if (rb.velocity.x == 0f && rb.velocity.y == 0f)
        {
            finalPosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

            finalX = finalPosition.x;
            finalY = finalPosition.y;

            dx = finalX - initialX;
            dy = finalY - initialY;

            //move the ball the opposite way of the line
            direction = new Vector2(-dx, -dy);

            //add the speed to the ball
            rb.AddForce(direction * swingForce);

            //get rid of the line
            line.SetPosition(0, new Vector3(0, 0, 0));
            line.SetPosition(1, new Vector3(0, 0, 0));
            lineObject.SetActive(false);

            //play the putt sound
            Putt.Play();
        }
        //add one to strokes
        Strokes++;
        //Debug.Log(Strokes);
        //run update text in game controller
        GameController.instance.UpdateText();

    }
    private void OnMouseDrag()
    {
        positionTwo = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        line.SetPosition(1, positionTwo);
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        //if you enter a hole and the ball is slow enough...
        if (Other.gameObject.CompareTag("Hole1") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
          // Debug.Log("Holled it!");
          //set position to the hole
            transform.position = new Vector2(hole.transform.position.x, hole.transform.position.y);

            //stop the ball
            rb.velocity = new Vector2(0f, 0f);

            //run scripts from gamecontroller
            GameController.instance.Feedback();
            GameController.instance.winChecker();

            //play the hole in sound
            HoleIn.Play();
        }
        //if you enter a transfer hole and the ball is slow enough...
        if (Other.gameObject.CompareTag("Transfer hole") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
            //move the ball to the transformer's position
            transform.position = new Vector2(Transformer.transform.position.x, Transformer.transform.position.y);

            //play the hole in sound
            HoleIn.Play();
        }
        //if you enter the fake transfer hole and the ball is slow enough...
        if (Other.gameObject.CompareTag("Fake Transfer Hole") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
            //set the ball's position to the fake transporter
            transform.position = new Vector2(FakeTransporter.transform.position.x, FakeTransporter.transform.position.y);

            //play the hole in sound
            HoleIn.Play();
        }
        //if you enter the water
        if (Other.gameObject.CompareTag("Water"))
        {
            // Debug.Log("WET!");
            //stop the ball
            rb.velocity = new Vector2(0f, 0f);
            //set the drag of the ball to 5
            rb.drag = 5;

            //play the sploosh sound
            Sploosh.Play();
        }
    }
    
    void OnTriggerExit2D(Collider2D Other)
    {
        //if the ball exit's the water
        if (Other.gameObject.CompareTag("Water"))
        {
            //set the drag to 0.6
            rb.drag = 0.6f;
        }
    }
}
