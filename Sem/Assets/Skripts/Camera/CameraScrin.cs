using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrin : MonoBehaviour {

    public GameObject pl1;
    public GameObject mainCam;
    public List<GameObject>Controls;
    Camera myCam;
    public bool isFerst = true;
    public bool isMin = false;

    private float X;
    private float Y;
    private float Z;


 
    


    float start;
    public float distants;
    public float Withs;
    public float He;
    public virtual void FollowMod()
    {
        isFerst = !isFerst;
    }
    public virtual void IsMaxMod()
    {
        isMin = !isMin;

        //if(isMin)
        //{

        //    myCam.orthographicSize = distants;
        //    foreach (GameObject e in Controls)
        //        e.active = false;
        //}
        //else
        //{
        //    myCam.orthographicSize = start;          
        //    foreach (GameObject e in Controls)
        //        e.active = true;

        //}
    }

    private void Start()
    {
        
        
      //  Controls1.Add(temp)


        X = transform.position.x;
        Y = transform.position.y;
        Z = transform.position.z;

        myCam =GetComponent<Camera>();
        start = myCam.orthographicSize;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
    // Update is called once per frame
    
    void Update () {


       

                transform.position = new Vector3(X + pl1.transform.position.x + He, Y + pl1.transform.position.y + Withs, Z + pl1.transform.position.z);
       

    }
}
