using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

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
    private bool is_Touching = false;
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
                    is_Move = Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began || Input.GetMouseButtonDown(0);

                    if (Input.touchCount > 0)
                    {
                        touch = Input.touches;
                        if (touch[0].phase == TouchPhase.Began)
                        {

                            Ray ray = Camera.main.ScreenPointToRay(touch[0].position);

                            //RaycastHit2D _hit_2D = Physics2D.Raycast(Camera.main.ScreenToViewportPoint(touch[0].position),Vector2.zero);

                            //if (_hit_2D!=null)
                            //{
                            //    m.text = _hit_2D.transform.gameObject.tag;
                            //}

                            if (Physics.Raycast(ray, out hit))
                            {
                                if (hit.transform.gameObject.tag == "floor")
                                {
                                    is_Move = true;
                                }
                                else if (hit.transform.gameObject.tag == "fridge")
                                {
                                    is_Move = true;
                                    is_actions = true;
                                }
                                else
                                {
                                    
                                    is_Move = false;
                                   
                                }
                            }
                        }
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {

                        
                        //RaycastHit2D _hit_2D = Physics2D.Raycast(Camera.main.ScreenToViewportPoint(Input.mousePosition), Vector2.zero);

                        //if (_hit_2D != null)
                        //{
                        //    UnityEngine.Debug.Log(_hit_2D.collider.GetComponentInParent<RectTransform>().sizeDelta);
                          
                        //   // if (_hit_2D.transform.gameObject.tag=="Speek")
                           
                        //}

                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit))
                        {
                           // m.text = hit.transform.gameObject.tag;
                            if (hit.transform.gameObject.tag == "floor")
                            {
                                is_Move = true;
                                is_actions = false;
                               
                            }
                            else if (hit.transform.gameObject.tag == "fridge")
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
