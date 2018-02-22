using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Diagnostics;

[RequireComponent(typeof(MoweHerow))]
public class InputHerow : Unit
{


    private RaycastHit hit;
    public float speed = 1.3F;

    private MoweHerow c_movement = null;

    private bool isJumping = false;
    private bool isRun = false;
    private bool isUsed = false;

    private bool isActive = false;

    private bool is_Move = false;
  

    private bool isDoubleCR = false;
    private bool isDoubleCL = false;

    public bool stop = true;
    public bool Activ = true;

    float currentTime = 0;
    float lastClickTime = 0;
    float clickTime = 0.2F;

    Touch[] touch;
    void Awake()
    {
        //References
        c_movement = GetComponent<MoweHerow>();
    }

    public void IsStop()
    {
        stop = !stop;
    }

    void Update()
    {
        if (stop)
            if (Activ)
            {

             
                if (!isJumping)
                {
                  
                  //  isJumping = CnInputManager.GetButtonUp("Jump");
                }
                if (!isRun)
                {
                  
                 //   isRun = CnInputManager.GetButton("Run");
                }
                if (!isUsed)
                {  
                 //   isUsed = CnInputManager.GetButton("Used");
                }

                if (!is_Move)
                {
                    is_Move = /*Input.touchCount > 0 ||*/ Input.GetMouseButtonDown(0);

                 
                }
                if (/*Input.touchCount > 0 &&*/ is_Move)
                {
                   // foreach (Touch touch in Input.touches)
                    {
                        //if (touch.phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                            if (Physics.Raycast(ray, out hit))
                            {


                                if (hit.transform.gameObject.tag == "floor")
                                {
                                    is_Move = true;
                                }

                            }
                        
}
                    }
                    touch = Input.touches;
                }



                //if (!isDoubleCL)
                //{

                //    if (CnInputManager.GetButtonDown("LeftButton"))
                //    {
                //        isDoubleCR = false;
                //        currentTime = Time.time;
                //        if ((currentTime - lastClickTime) < clickTime)
                //        {
                //            isDoubleCL = true;
                //        }
                //        lastClickTime = currentTime;
                //    }
                //}
                //if (CnInputManager.GetButtonUp("LeftButton") && isDoubleCL)
                //{
                //    isDoubleCL = false;
                //}

                //if (!isDoubleCR)
                //{

                //    if (CnInputManager.GetButtonDown("RightButton"))
                //    {
                //        isDoubleCL = false;
                //        currentTime = Time.time;
                //        if ((currentTime - lastClickTime) < clickTime)
                //        {
                //            isDoubleCR = true;
                //        }
                //        lastClickTime = currentTime;
                //    }
                //}
                //if (CnInputManager.GetButtonUp("RightButton") && isDoubleCR)
                //{
                //    isDoubleCR = false;
                //}

            }
    }

    private void FixedUpdate()
    {

        if (Activ)
        {
            //Get horizontal axis
            //float horizontal=0;// = CnInputManager.GetAxis("Horizontal");         

            //Call movement function in PlayerMovement
            c_movement.Move(ref is_Move, isDoubleCR, isDoubleCL, isJumping, isRun, isUsed, touch, hit);
            //Reset
            isJumping = false;
            isRun = false;
            isUsed = false;

            is_Move = false;
           

        }
        else
        {
           // c_movement.Follow();
        }
    }

    public virtual void FollowMod()
    {
        Activ = !Activ;
    }

    public virtual void FollowModOn()
    {
        Activ = false;
    }

    public virtual void FollowModOff()
    {
        Activ = true;
    }
}
