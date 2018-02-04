using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform camera_child;
    public Transform camera_transform;


    public float Zs;
    public float Xs;

    public float Ye = 0;
    public float Ze = 0;


    public float ygol = 1;
    public float ygol2 = 1;
    // Use this for initialization
    void Start () {
        camera_child = transform.FindChild("camera_child");
        camera_transform = camera_child.FindChild("Main Camera");
      

    }

    void Position()
    {
        if (Input.GetKey("q"))
        {
            if (Xe == 0 && Ye == 0)
            {

            }
            else if ()
            {

            }
            else if ()
            {

            }
            else if ()
            {

            }
        }
    }
    // Update is called once per frame
    void Update () {
        

	}
}
