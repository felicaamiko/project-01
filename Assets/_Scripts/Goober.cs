using UnityEngine;

//TODO
/*
 
 goofer rotation does not work (almost there)
 need to detect if collided with goofer, and if i landed on goofer (y transform check?)

add "states" to the menu
 add a script that never dies
 add death and killing to work. 
 add 
 
 
 
 
 */
public class Goober : MonoBehaviour
{
    private string state = "idle";
    public static Vector3 crosshair;
    private float ydiff;

    private float prev;
    private float curr;
    private bool isgrounded;

    public GameObject thisobject;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (prev*100 - curr*100 == 0) { isgrounded = true; }
        if (prev * 100 - curr*100 != 0) { isgrounded = false; }
        //Debug.Log(prev - curr + "<prev-curr" + isgrounded + "<gr");
        Debug.Log(curr);
        prev = curr;
        curr = transform.position.y;
        crosshair = transform.position;

 




        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))//issue; getkeydown can be held?
        {
            //Debug.Log("jumped");
            rb.AddForce(Vector3.up * 400);//needs to be stronger than gravity (9.81)
            //rb.AddExplosionForce(10, Vector3.up, 1);//needs to be stronger than gravity (9.81)
        }



    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("goober touched");
        ydiff = crosshair.y - Goofer.crosshair.y;
        Debug.Log(collision);
        Debug.Log(ydiff);
    }

    static void Jump()
    {
        //rb.AddForce(Vector3.up * 400);
    }
}
