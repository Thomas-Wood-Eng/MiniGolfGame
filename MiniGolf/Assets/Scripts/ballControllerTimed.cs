using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControllerTimed : MonoBehaviour
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
        //declare starts
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
        if (rb.velocity.x < 0.5 || rb.velocity.x > -0.5 && rb.velocity.y < 0.5 || rb.velocity.y > -0.5 && rb.velocity.x != 0 && rb.velocity.y != 0)
        {
            //add to slowtime
            slowTime += Time.deltaTime;
            //Debug.Log(slowTime);
            //if slowtime is active for two seconds...
            if (slowTime >= 2)
            {
                //stop the ball
                rb.velocity = new Vector2(0f, 0f);
            }
        }
        // if the ball speeds up...
        if (rb.velocity.x > 0.5 || rb.velocity.x < -0.5 && rb.velocity.y > 0.5 || rb.velocity.y < -0.5)
        {
            //reset slowtime
            slowTime = 0;
            //Debug.Log("RESET");
        }
        //if the ball has stopped...
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            //reset slowtime
            slowTime = 0;
            //Debug.Log("RESET b/c 0");
        }
    }


    private void OnMouseDown()
    {
        //show the line
        lineObject.SetActive(true);

        initialX = transform.position.x;
        initialY = transform.position.y;

        positionOne = new Vector3(initialX, initialY, 0);
        line.SetPosition(0, positionOne);
    }
    private void OnMouseUp()
    {
        //if the ball is stopped...
        if (rb.velocity.x == 0f && rb.velocity.y == 0f)
        {
            finalPosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

            finalX = finalPosition.x;
            finalY = finalPosition.y;

            dx = finalX - initialX;
            dy = finalY - initialY;

            //move the ball in the opposite direction of the line
            direction = new Vector2(-dx, -dy);
            rb.AddForce(direction * swingForce);

            //Get rid of the line
            line.SetPosition(0, new Vector3(0, 0, 0));
            line.SetPosition(1, new Vector3(0, 0, 0));
            lineObject.SetActive(false);

            //play the putt sound
            Putt.Play();

        }
        //add one to strokes
        Strokes++;
       // Debug.Log(Strokes);

        //run function in gamecontroller
      

    }
    private void OnMouseDrag()
    {
        positionTwo = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        line.SetPosition(1, positionTwo);
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        //if it hits a hole...
        if (Other.gameObject.CompareTag("Hole1") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
            //Debug.Log("Holled it!");
            //set the ball's position to the hole's
            transform.position = new Vector2(hole.transform.position.x, hole.transform.position.y);
            //stop the ball
            rb.velocity = new Vector2(0f, 0f);

            //run functions
           
            GameControllerTimed.instance.winChecker();

            //play hole in sound
            HoleIn.Play();


        }
        //if you enter a trasfer hole...
        if (Other.gameObject.CompareTag("Transfer hole") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
            //move the ball to the trasformer's position
            transform.position = new Vector2(Transformer.transform.position.x, Transformer.transform.position.y);

            //play hole in sound
            HoleIn.Play();
        }
        //if you enter a fake transfer hole...
        if (Other.gameObject.CompareTag("Fake Transfer Hole") && rb.velocity.x < 7f && rb.velocity.y < 7f)
        {
            //move the ball to the fake transformer's position
            transform.position = new Vector2(FakeTransporter.transform.position.x, FakeTransporter.transform.position.y);

            //play hole in sound
            HoleIn.Play();
        }
        //if you enter water...
        if (Other.gameObject.CompareTag("Water"))
        {
            //Debug.Log("WET!");
            //stop the ball
            rb.velocity = new Vector2(0f, 0f);
            //increase the drag
            rb.drag = 5;
            //play the sploosh sound
            Sploosh.Play();
        }

    }
    void OnTriggerExit2D(Collider2D Other)
    {
        //if you exit the water...
        if (Other.gameObject.CompareTag("Water"))
        {
            //reduced the drag
            rb.drag = 0.6f;
        }
    }

}
