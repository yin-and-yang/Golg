using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MoweHerow : Unit
{
    #region Pole 
    #region Audio
    public AudioClip[] FootSteps;
    public AudioClip fallClip;
    public AudioSource audioSource;
    public AudioSource fallAudio;
    #endregion Audio
    [SerializeField]
    NavMeshAgent agent;

    bool IsStep = false;
    float StopStep;
    public float StartStopStep;
    public float speed_my = 1.3f;

    Vector3 now_unit_herow;
   public Transform X_cord_perspective;
    float result_perspective_x;

    private float memor_speed;
    public float run;
    public float jump = 5f;

    private float move_x = 0;
    private float move_y = 0;

    private bool RandL = true;
    private bool isGrounded = false;
    private bool isGroundedStart = false;
    public bool is_action=false;

   

    #region GUI
    private Image Use_UI;
    private Image Speek_UI;
    private Image Look_UI;
    public GameObject my_Actions;
    public float offSetZ;
    #endregion GUI

    private NavMeshAgent myAgent;
    private Animator g_Animator;
  
    private Vector3 direction;

    RaycastHit _hit;
    public GameObject my_sprite;

    float times = 0.2f;
    public float speedStopWall = 1f;

    #endregion Pole
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        
        g_Animator = GetComponent<Animator>();
        now_unit_herow = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Start()
    {
        memor_speed = speed_my;
        direction = transform.right;


    }
    void FixedUpdate()
    {
        // if (Activ)
        {
            isGrounded = false;

         
      
          

            #region Audio
            //if (move_x !=0)
            //{
            //    if (isGrounded)
            //        MoweAudio();
            //}
            //else if (!IsStep)
            //{
            //    StopAudio();
            //}

            //if (isGrounded && !isGroundedStart)
            //{
            //    DownAudio();
            //}
            #endregion Audio

            isGroundedStart = isGrounded;
        }
    }
    private void Update()
    {

        Context_Menu();
        if (Times())
            time = true;
    }
    ////////////////////////////////////////////////////////////

    void Size_picture()
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), 1f);
        foreach (Collider c in colliders)
        {
           
            if (c.tag == "Ground_kithen")
            {
                result_perspective_x = -
                      (transform.position.x <= X_cord_perspective.position.x ?  X_cord_perspective.position.x - transform.position.x :  transform.position.x- X_cord_perspective.position.x );

                my_sprite.transform.localScale = new Vector3((my_sprite.transform.position.z * 100 / now_unit_herow.z ) / 100.0f + .1f - result_perspective_x
                    , (my_sprite.transform.position.z * 100 / now_unit_herow.z) / 100.0f + .1f - result_perspective_x,
                   .1f );
                transform.localScale = new Vector3((transform.position.z * 100 / now_unit_herow.z) / 100.0f
                    , (transform.position.z * 100 / now_unit_herow.z) / 100.0f,
                  (transform.position.z * 100 / now_unit_herow.z) / 100.0f);




                //Интересно 
                /*
               result_perspective_x = -
                      (transform.position.x <= X_cord_perspective.position.x ? transform.position.x - X_cord_perspective.position.x : X_cord_perspective.position.x - transform.position.x);

                    my_sprite.transform.localScale = new Vector3((my_sprite.transform.position.z * 100 / now_unit_herow.z ) / 100.0f + .1f - result_perspective_x
                    , (my_sprite.transform.position.z * 100 / now_unit_herow.z) / 100.0f + .1f - result_perspective_x,
                   .1f );
                transform.localScale = new Vector3((transform.position.z * 100 / now_unit_herow.z) / 100.0f
                    , (transform.position.z * 100 / now_unit_herow.z) / 100.0f,
                  (transform.position.z * 100 / now_unit_herow.z) / 100.0f);
                  */


                /*

                my_sprite.transform.localScale = new Vector3((my_sprite.transform.position.z * 100 / now_unit_herow.z) / 100.0f + .1f
                     , (my_sprite.transform.position.z * 100 / now_unit_herow.z) / 100.0f + .1f,
                     (my_sprite.transform.position.z * 100 / now_unit_herow.z) / 100.0f + .1f);
                transform.localScale = new Vector3((transform.position.z * 100 / now_unit_herow.z) / 100.0f 
                      , (transform.position.z * 100 / now_unit_herow.z) / 100.0f ,
                    (transform.position.z * 100 / now_unit_herow.z) / 100.0f);
                    */

            }
        }
    }

    void CheckGrounded()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 1.5f), 0.3f);
        foreach (Collider2D c in colliders)
        {
            if (c.tag == "Ground")
            {                                         
               
                isGrounded = true;
                g_Animator.SetBool("Ground", true);

               

                return;
            }
            else
            {
                g_Animator.SetBool("Ground", false);
                isGrounded = false;
            }

        }

    }
    ////////////////////////////////////////////////////////////

    public void Move( bool  is_Move, bool is_actions, bool isDoubleR, bool isDoubleL, bool isJumping, bool isRun, bool isUsed, Touch [] t, RaycastHit hit)
    {
       


        if (isDoubleR || isDoubleL)
            isRun = true;

        if (is_Move)
        {
            _hit = hit;


          

            agent.SetDestination(hit.point);



            move_x = myAgent.velocity.x >= 0 ? (myAgent.velocity.x == 0 ? 0 : 1) : (myAgent.velocity.x < 0 ? -1 : 0);
            move_y = myAgent.velocity.z >= 0 ? (myAgent.velocity.z == 0 ? 0 : 1) : (myAgent.velocity.z < 0 ? -1 : 0);

            is_action = is_actions;
        }
        else
        {
           
            move_x = 0;
            move_y = 0;
        }
        Size_picture();


        #region is Ground
        //if (isGrounded && isJumping)
        //{
        //    isJumping = false;
        //    g_Animator.SetBool("Ground", false);
        //    g_Rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        //}
        //else if (isJumping && countFlay<maxCountFlay)
        //{
        //    countFlay++;
        //    isJumping = false;
        //    g_Animator.SetBool("Ground", false);
        //    g_Rigidbody2D.AddForce(new Vector2(0f, jump/2), ForceMode2D.Impulse);
        //}

        //if (isGrounded && isUsed && g_Animator.GetBool("Ground"))
        //{
        //    isUsed = false;
        //    //Attack();
        //    Used();
        //}
        #endregion is Ground
    }


    #region ContextMenu

    public void Context_Menu()
    {
      
        if (is_action)
        {
           
            if (Mathf.Abs( transform.position.x )>= Mathf.Abs(_hit.point.x)-1 && Mathf.Abs(transform.position.x )<= Mathf.Abs(_hit.point.x) + 1 &&
                Mathf.Abs(transform.position.z) >= Mathf.Abs(_hit.point.z) - 1 && Mathf.Abs(transform.position.z) <= Mathf.Abs(_hit.point.z) + 1&&
                myAgent.velocity.x==0 && myAgent.velocity.y == 0)
            {
                my_Actions.transform.position = new Vector3(transform.position.x, my_Actions.transform.position.y, transform.position.z + offSetZ);
                my_Actions.SetActive(true);

            }
            else
            {
                my_Actions.SetActive(false);
            }
        }
        else
        {
            my_Actions.SetActive(false);
        }
    }
    #region actions
    void Used()
    {

    }
    ////////////////////////////////////////////////////////////
    //void Attack()
    //{
    //    gameObject.GetComponent<Animator>().SetTrigger("attack");
    //}

    ////////////////////////////////////////////////////////////
    #endregion actions
    #endregion



    #region CheckPleyar
    //void CheckPleyar()
    //{
    //    if (g_Object.Length != 0)
    //    {
    //        Transform player = g_Object[0].transform;
    //        if (player.position.x < transform.position.x)
    //        {
    //            direction.x = -1f;
    //            RandL = false;

    //        }
    //        else if (player.position.x > transform.position.x)
    //        {
    //            direction.x = 1f;
    //            RandL = true;

    //        }
    //    }
    //}
    #endregion CheckPleyar

  
    ////////////////////////////////////////////////////////////
    #region Timer
    private bool time = false;
    public float timer = 2f;
    public float stay_timer = 2f;
    bool Times()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return false;
        }
        else if (timer < 0)
        {
            timer = stay_timer;
            return true;
        }
        return false;
    }
    #endregion Timer
    ////////////////////////////////////////////////////////////
    #region Audio
    //void MoweAudio()
    //{


    //    if (IsStep)
    //    {

    //        audioSource.PlayOneShot(FootSteps[Random.Range(0, FootSteps.Length)]);

    //        IsStep = false;
    //    }


    //    if (StopStep < 0)
    //    {
    //        StopStep = StartStopStep;
    //        IsStep = true;
    //    }
    //    if (StopStep > 0)
    //        StopStep -= Time.deltaTime;


    //}
    //void DownAudio()
    //{        
    //        fallAudio.PlayOneShot(fallClip); 
    //}
    //void StopAudio()
    //{
    //    audioSource.Stop();

    //    StopStep = StartStopStep;
    //    IsStep = true;
    //}
    #endregion Audio
}
