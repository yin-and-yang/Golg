using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MoweHerow : Unit
{
    public AudioClip[] FootSteps;
    public AudioClip fallClip;
    public AudioSource audioSource;
    public AudioSource fallAudio;

    [SerializeField]
    NavMeshAgent agent;

    bool IsStep = false;
    float StopStep;
    public float StartStopStep;

   

    Vector3 position;

    private float memor_speed;
    public float run;
    public float jump = 5f;

    private float move_x = 0;
    private float move_y = 0;

    private bool RandL = true;
    private bool isGrounded = false;
    private bool isGroundedStart = false;
    public bool is_action=false;

    public int countFlay;
    public int maxCountFlay;

    private Image Use_UI;
    private Image Speek_UI;
    private Image Look_UI;
    public GameObject my_Actions;
    public float offSetZ;


    private NavMeshAgent myAgent;
    private Animator g_Animator;
    private SpriteRenderer sprite;
    private Rigidbody2D g_Rigidbody2D;
    private Vector3 direction;
 //   GameObject[] g_Object;
    RaycastHit _hit;
    public GameObject my_sprite;

    float times = 0.2f;
    public float speedStopWall = 1f;

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
         g_Rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        g_Animator = GetComponent<Animator>();

    }
    void Start()
    {
        memor_speed = speed;
        direction = transform.right;

      
    //    g_Object = GameObject.FindGameObjectsWithTag("Player2");

        //if (g_Object.Length != 0)
        //{
        //    Transform player = g_Object[0].transform;
        //    Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //}
    }
    void FixedUpdate()
    {
        // if (Activ)
        {
            isGrounded = false;

         
          //  CheckGrounded();
         

            //g_Animator.SetBool("Ground", isGrounded);        
          
         //   g_Animator.SetFloat("vSpeed", g_Rigidbody2D.velocity.y);
          

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
    void CheckGrounded()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y - 1.5f), 0.3f);
        foreach (Collider2D c in colliders)
        {
            if (c.tag == "Ground")
            {                                         
               
                isGrounded = true;
                g_Animator.SetBool("Ground", true);

                countFlay = 0;

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


            // transform.position = new Vector3(Mathf.Lerp(transform.position.x, hit.point.x, 5 * Time.deltaTime * speed), transform.position.y, Mathf.Lerp(transform.position.z, hit.point.z, 5 * Time.deltaTime * speed));
            //  transform.position = Vector3.Lerp(transform.position, hit.point, Time.deltaTime * speed);  

            agent.SetDestination(hit.point);

            //  move_x = transform.position.x > hit.point.x ? -1 : 1;
            // move_y = transform.position.z > hit.point.z ? -1 : 1;


            move_x = myAgent.velocity.x >= 0 ? (myAgent.velocity.x == 0 ? 0 : 1) : (myAgent.velocity.x < 0 ? -1 : 0);
            move_y = myAgent.velocity.z >= 0 ? (myAgent.velocity.z == 0 ? 0 : 1) : (myAgent.velocity.z < 0 ? -1 : 0);

            is_action = is_actions;
        }
        else
        {
           
            move_x = 0;
            move_y = 0;
        }

       
      
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
