
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using CnControls;


[RequireComponent(typeof(MoweHerow))]
public class InputHerow : Unit
{
   
    private RaycastHit hit;

    //private RaycastHit2D _hit_2D;

    public float speed = 1.3F;

    private MoweHerow c_movement = null;

    private bool isJumping = false;
    private bool isRun = false;
    private bool isUsed = false;

    private bool isActive = false;

   

    private bool is_Look = false;
    private bool is_Use = false;
    private bool is_Speek = false;

    private bool is_actions = false;

    private bool is_Move = false;
  

    private bool isDoubleCR = false;
    private bool isDoubleCL = false;

    public bool stop = true;
    public bool Activ = true;

    float currentTime = 0;
    float lastClickTime = 0;
    float clickTime = 0.2F;
    public Text m;
    Touch[] touch;
    void Awake()
    {
        //References
        c_movement = GetComponent<MoweHerow>();
       // _hit_2D = new RaycastHit2D();
    }

    public void IsStop()
    {
        stop = !stop;
    }

    void Update()
    {
        touch = Input.touches;


                if (!is_Look)
                {
                    is_Look = CnInputManager.GetButtonDown("Look");
             
                   
                }
                if (!is_Use)
                {
                    is_Use = CnInputManager.GetButtonDown("Use");

                   

                }
                if (!is_Speek)
                {
                    is_Speek = CnInputManager.GetButtonDown("Speek");
            

                }

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

                if (!is_Move && !is_Speek && !is_Use&& !is_Look)
                {




                    is_Move = touch.Length > 0 && touch[0].phase == TouchPhase.Began || Input.GetMouseButtonDown(0);

                    if (touch.Length  > 0)
                    {
                        
                        if (touch[0].phase == TouchPhase.Began)
                        {

                            Ray ray = Camera.main.ScreenPointToRay(touch[0].position);

                          

                            if (Physics.Raycast(ray, out hit))
                            {
                                if (hit.transform.gameObject.tag == "floor" || hit.transform.gameObject.tag == "Ground_kithen")
                                {
                                    is_Move = true;
                                }
                                else if (hit.transform.gameObject.tag == "fridge"|| hit.transform.gameObject.tag == "curbstone")
                                {

                                    is_Move = true;
                                    is_actions = true;
                                }
                                else
                                {

                                    is_Move = false;
                                     is_actions = false;
                                }
                            }
                        }
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {




                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                     //  UnityEngine.Debug.Log(Input.mousePosition);
 
                        bool isHit = Physics.Raycast(ray, out hit);
                        if (isHit)
                        {

                            // m.text = hit.transform.gameObject.tag;
                            if (hit.transform.gameObject.tag == "floor"||
                                hit.transform.gameObject.tag == "Ground_kithen"||
                                hit.transform.gameObject.tag == "Left_map")
                            {
                                is_Move = true;
                                is_actions = false;

                            }
                            else if (hit.transform.gameObject.tag == "fridge" || hit.transform.gameObject.tag == "curbstone")
                            {
                                is_Move = true;
                                is_actions = true;

                            }
                            else
                            {
                                is_Move = false;
                                 is_actions = false;
                            }
                        }

                        //GameObject _lineObject = new GameObject();
                        //LineRenderer _line = _lineObject.AddComponent<LineRenderer>();
                        //_line.SetPosition(0, ray.origin);
                        //if (isHit)
                        //    _line.SetPosition(1, hit.point);
                        //else
                        //    _line.SetPosition(1, ray.direction);
                        //_line.SetWidth(0.05f, 0.05f);
                        //Destroy(_lineObject, 0.5f);
                    }
                }
             else
             {
                c_movement.is_action=false;
             }
               

            
               
                

                #region
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
                #endregion
    }
    
   

    private void FixedUpdate()
    {

        if (Activ)
        {
            //Get horizontal axis
            //float horizontal=0;// = CnInputManager.GetAxis("Horizontal");         

            //Call movement function in PlayerMovement
            c_movement.Move( is_Move,is_actions, isDoubleCR, isDoubleCL, isJumping, isRun, isUsed, touch, hit);
            //Reset
            isJumping = false;
            isRun = false;
            isUsed = false;
            is_Move = false;
            is_actions = false;


             is_Look = false;
            is_Speek = false;
            is_Use = false;
          
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
