using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform camera_child;
    public Transform camera_transform;
    public GameObject pl1;

    ///////////////////////////////////////////////



    private bool isKey = false;
    private float X;
    private float Y;
    private float Z;

    public int positionCamera = 3;
    public float Withs;
    public float He;
    public double interval = 5;
    public float cosPovorot = 0.05f;
    public float speedRotate = 15f;
    ///////////////////////////////////////////////
    public Vector3 startMarker;
    public Vector3 endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    ///////////////////////////////////////////////
    public float Xe = -1;
    public float Ze = -1;
    public int roterePandN = 1;
    public bool isMowe = true;

    // Use this for initialization
    void Awake()
    {
       
    }
    void Start () {
        camera_child = transform.FindChild("camera_child");
        camera_transform = camera_child.FindChild("Main Camera");

        isKey = false;
        isMowe = true;
        X = transform.position.x;
        Y = transform.position.y;
        Z = transform.position.z;

        endMarker = new Vector3(X * Xe + pl1.transform.position.x + He, Y + pl1.transform.position.y + Withs, Z * Ze + pl1.transform.position.z);
        startMarker = new Vector3(X * Xe + pl1.transform.position.x + He, Y + pl1.transform.position.y + Withs, Z * Ze + pl1.transform.position.z);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);


    }
    private  void OnTimedEvent()
    {
      
 
        transform.Rotate(0, -1 * speedRotate * Time.deltaTime * roterePandN, 0);

       
     
        if (transform.rotation.eulerAngles.y <= 270&& positionCamera == 0 && roterePandN == 1||
            transform.rotation.eulerAngles.y >= 270 && positionCamera == 0 && roterePandN == -1)
        {
           
            CancelInvoke();
            isMowe = true;
        }
        else if(transform.rotation.eulerAngles.y <= 180&& positionCamera == 1 && roterePandN == 1||
            transform.rotation.eulerAngles.y >= 180 && positionCamera == 1 && roterePandN == -1)
        {
            
            CancelInvoke();
            isMowe = true;
        }
        else if (transform.rotation.eulerAngles.y >= 90 && positionCamera == 2&& roterePandN== -1||
                transform.rotation.eulerAngles.y <= 90 && positionCamera == 2 && roterePandN == 1)
        {
           
            CancelInvoke();
            isMowe = true;
        }
        else if (transform.rotation.eulerAngles.y <= 1 && positionCamera == 3 && roterePandN == 1||
                 transform.rotation.eulerAngles.y <= 1 && positionCamera == 3 && roterePandN == -1)
        {
          
            CancelInvoke();
            isMowe = true;
        }

    }
    public void InputSvapLeft()
    {
        if (isMowe)
        {
            if (positionCamera == 0)
                positionCamera = 3;
            else
                positionCamera--;

            roterePandN = -1;
            isKey = true;
        }
    }
    public void InputSvapRith()
    {
        if (isMowe)
        {
            if (positionCamera == 3)
                positionCamera = 0;
            else
                positionCamera++;

            roterePandN = 1;
            isKey = true;
        }
    }
    public void MoweCam(bool left)
    {
        if(isMowe)

           
        if (!left)
        {
            if (positionCamera == 3)

                positionCamera = 0;
            else
                positionCamera++;
            roterePandN = 1;
            isKey = true;
        }
        else
        {
            if (positionCamera == 0)
                positionCamera = 3;
            else
                positionCamera--;

            roterePandN = -1;
            isKey = true;
        }

       
    }
    private void Position()
   {

      
        if (isKey && isMowe)
        {
            Debug.Log(isMowe);
            isKey = false;
            isMowe = false;
            startMarker = new Vector3(X * Xe + pl1.transform.position.x + He, Y + pl1.transform.position.y + Withs, Z * Ze + pl1.transform.position.z);

            //  if (Xe == -1 && Ze == -1)
            if (positionCamera==0)
            {
                Ze = -1;
                Xe = 1;
                He = 5.47f;
                Withs = 3.54f;
                Debug.Log("yo");
                // transform.Rotate(0,-90* roterePandN, 0);
                InvokeRepeating("OnTimedEvent", 0f, cosPovorot*Time.deltaTime);
            }
            // else if (Xe == 1 && Ze == -1)
            if (positionCamera == 1)
            {
                Ze = 1;
                Xe = 1;
                Withs = -2.33f;
                He = -5.47f;
                // transform.Rotate(0, -90* roterePandN, 0);
                InvokeRepeating("OnTimedEvent", 0f, cosPovorot * Time.deltaTime);
            }
            //else if (Xe == 1 && Ze == 1)
            if (positionCamera == 2)
            {
                Ze = 1;
                Xe = -1;
                He = -5.47f;
                Withs = 3.54f;
                //  transform.Rotate(0, -90* roterePandN, 0);
                InvokeRepeating("OnTimedEvent", 0f, cosPovorot * Time.deltaTime);
            }
            //else if (Xe == -1 && Ze == 1)
            if (positionCamera == 3)
            {
                He = 5.47f;
                Withs =0f;
                Ze = -1;
                Xe = -1;
                //  transform.Rotate(0, -90* roterePandN, 0);
                InvokeRepeating("OnTimedEvent", 0f, cosPovorot * Time.deltaTime);
            }
            endMarker = new Vector3(X * Xe + pl1.transform.position.x + He, Y + pl1.transform.position.y + Withs, Z * Ze + pl1.transform.position.z);
            startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker, endMarker);
          
        }

    }
    // Update is called once per frame
    //public float speedCam = 15;
    // public float speedScroll = 15;
    // public float minDistance;
    // public float maxDistance;

    // private bool _isActive = false;
    //  private float _distance;
    //  private float _x;
    //  private float _y;

    //if (transform.position.x< 50f)
    //   {
    //       transform.position += new Vector3(Mathf.Lerp(0, 1, 20 * Time.deltaTime), 0, 0);
    //   }

   
    void Update() {
      
        Position();
         
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength ;

        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
    

        //transform.position = new Vector3(X*Xe + pl1.transform.position.x + He , Y + pl1.transform.position.y + Withs, Z*Ze + pl1.transform.position.z);

        //_x = Input.GetAxis("Mouse X") * speedCam * 10;
        //_y = Input.GetAxis("Mouse Y") * -speedCam * 10;
        //if(Input.GetMouseButtonDown(1))
        //{
        //    _isActive = true;
        //}
        //if(Input.GetMouseButtonUp(1))
        //{
        //    _isActive = false;
        //}
        //if(_isActive)
        //{
        //    transform.RotateAround(pl1.transform.position, transform.up, _x * Time.deltaTime);
        //   // transform.RotateAround(pl1.transform.position, transform.right, _y* Time.deltaTime);
        //    //transform.rotation = Quaternion.LookRotation(pl1.transform.position - transform.position);
        //   // transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        //}
    }   
    
}
