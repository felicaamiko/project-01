using UnityEngine;

//TODO
/*
 
 goofer rotation does not work (almost there)
 need to detect if collided with goofer, and if i landed on goofer (y transform check?)

add "states" to the menu
 add a script that never dies
 add death and killing to work.or not? 
 add 
 
 
 
 
 */
public class Goober : MonoBehaviour
{
    private string state = "idle";
    public static Vector3 crosshair;
    private float ydiff;

    private float prev;
    private float curr;
    public static bool isgrounded = true;

    private Vector2 currvec;
    private Vector2 prevprevprevvec;
    private Vector2 prevprevvec;
    private Vector2 prevvec;
    private Vector2 forwardvec;
    private float rotangle;
    private float prevrotangle;

    private Quaternion finaloverriderotation;
    private Vector3 finalrot;
    private Vector3 normfinalrot;
    private Vector3 leaprot;

    private int counter;

    public GameObject thisobject;
    Rigidbody rb;
    public static bool istapped = false;

    public static bool istouched = false;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hitsound;
    [SerializeField] AudioSource audioSourcespeed;
    [SerializeField] AudioClip speedsound;
    [SerializeField] AudioSource audioSourcedeath;
    [SerializeField] AudioClip deathsound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (prev*100 - curr*100 == 0) { isgrounded = true; }
        //if (prev * 100 - curr*100 != 0) { isgrounded = false; }
        //if (counter > 100000000)
        //{
        //    prevvec = currvec;//collects a moment
        //    prevrotangle = rotangle;
        //    counter = 0;
        //}
        if (curr > -3) { isgrounded = true; }
        if (curr < -3 &&counter<100) { isgrounded = false;
            counter++;
            audioSourcedeath.PlayOneShot(deathsound);
        }
        //Debug.Log(prev - curr + "<prev-curr" + isgrounded + "<gr");
        //Debug.Log(curr);
        prev = curr;
        curr = transform.position.y;
        crosshair = transform.position;






        /*

        prevvec = currvec;
        currvec = new Vector2(transform.position.x, transform.position.z);
        forwardvec = currvec-prevvec;
        //rotangle = forwardvec.x + forwardvec.y;
        prevrotangle = rotangle;
        rotangle = Mathf.Atan2(forwardvec.y,forwardvec.x) * (180 / Mathf.PI);
        //Debug.Log("rot"+rotangle);//rot is in radians! pi must map to 180?

        
        //Debug.Log("rot" + rotangle);//rot is in degrees?
        finalrot = new Vector3(0, rotangle + 90, 0);
        //finalrot = (transform.localEulerAngles + finalrot)/2;
        transform.localEulerAngles = finalrot;
        */




        //transform.LookAt(new Vector3(Goofer.crosshair.x, 0, Goofer.crosshair.z), Vector3.up);

        //finaloverriderotation = Quaternion.Euler(0, 0, rotangle);
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += new Vector3(0, 0, Time.deltaTime * 2);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += new Vector3(-Time.deltaTime *2, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += new Vector3(0, 0, -Time.deltaTime * 2);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += new Vector3(Time.deltaTime * 2, 0, 0);
        //}
        float horiz = Input.acceleration.x * 1 * Time.deltaTime;
        float vert = Input.acceleration.y * 1 * Time.deltaTime;
        //float vert = (-Input.acceleration.z) * 0 * Time.deltaTime;
        Debug.Log(-Input.acceleration.z);
        transform.position += new Vector3(horiz, 0, vert);


        prevprevprevvec = prevprevvec;
        prevprevvec = prevvec;
        prevvec = currvec;
        currvec = new Vector2(horiz * 2, vert * 2);
        //forwardvec = (currvec + prevvec)*.5f;//could just be currvec
        forwardvec = (currvec + (prevvec + (prevprevvec + prevprevprevvec) * .5f) *.5f) * .5f;
        //rotangle = forwardvec.x + forwardvec.y;
        
        if (horiz != 0)//prevents NaN???
        {
            rotangle = Mathf.Atan2(forwardvec.y, forwardvec.x) * (180 / Mathf.PI);//abrasive?
        }
        //Debug.Log("rot"+rotangle);//rot is in radians! pi must map to 180?


        //Debug.Log("rot" + rotangle);//rot is in degrees?
        finalrot = new Vector3(0, -rotangle+90, 0);
        //finalrot = (transform.localEulerAngles + finalrot)/2;
        transform.localEulerAngles = finalrot;


        if (Input.GetKeyDown(KeyCode.Space))//issue; getkeydown can be held?
        {

            //leaprot = new Vector3(((prevrotangle + rotangle) / -2), 0, 0);
            //normfinalrot = leaprot.normalized;
            //Debug.Log("jumped");
            //Vector3(90, 0, rotangle-90);

            istapped = true;

            //rb.AddForce(normfinalrot * 20);
            //rb.AddForce(Vector3.forward * 20);//needs to be stronger than gravity (9.81), no longer jumps, now lurches forward. now dependent on mass
            //rb.AddExplosionForce(10, Vector3.up, 1);//needs to be stronger than gravity (9.81)
        }
        if (istapped)
        {
            rb.AddForce(transform.forward * 20);
            audioSourcespeed.PlayOneShot(speedsound);
            istapped = false;
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("goober touched");
        ydiff = crosshair.y - Goofer.crosshair.y;
        //Debug.Log(collision);
        //Debug.Log(ydiff);
        istouched = true;

        audioSource.PlayOneShot(hitsound);

    }

    private void OnCollisionExit(Collision collision)
    {
        istouched = false;
    }

    static void Jump()
    {
        //rb.AddForce(Vector3.up * 400);
    }
}
