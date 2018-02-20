﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoweRaven : Unit
{
    public AudioClip[] FootSteps;
    public AudioClip fallClip;
    public AudioSource audioSource;
    public AudioSource fallAudio;
    bool IsStep = false;
    float StopStep;
    public float StartStopStep;

    public Image UIHP;

    Vector3 position;

    private float memor_speed;
    public float run;
    public float jump = 5f;

    private float horizontal = 0;
    private bool RandL = true;
    private bool isGrounded = false;
    private bool isGroundedStart = false;

    public int countFlay;
    public int maxCountFlay;

    private Animator g_Animator;
    private SpriteRenderer sprite;
    private Rigidbody2D g_Rigidbody2D;
    private Vector3 direction;
    GameObject[] g_Object;

    GameObject Child;
    float times = 0.2f;
    public float speedStopWall = 1f;

    private void Awake()
    {
        Child = gameObject.transform.Find("Weapon_1").gameObject;


        g_Rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        g_Animator = GetComponent<Animator>();

    }
    void Start()
    {
        memor_speed = speed;
        direction = transform.right;

      
        g_Object = GameObject.FindGameObjectsWithTag("Player2");

        if (g_Object.Length != 0)
        {
            Transform player = g_Object[0].transform;
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    void FixedUpdate()
    {
        // if (Activ)
        {
            isGrounded = false;

         
            CheckGrounded();
            HPControl();

            g_Animator.SetBool("Ground", isGrounded);        
          
            g_Animator.SetFloat("vSpeed", g_Rigidbody2D.velocity.y);


            if (horizontal > 0 || horizontal < 0)
            {
                if (isGrounded)
                    MoweAudio();
            }
            else if (!IsStep)
            {
                StopAudio();
            }

            if (isGrounded && !isGroundedStart)
            {
                DownAudio();
            }
            isGroundedStart = isGrounded;
        }
    }
    private void Update()
    {
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
    public void Follow()
    {


        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + transform.right * 3f * direction.x, new Vector2(2.5f, 7), 90);
        bool isP = true;
        foreach (Collider2D c in colliders)
        {

            if (c.tag == "Player2" &&
               Mathf.Abs(c.transform.position.x - transform.position.x) > 3)
            {

                if (RandL)
                    horizontal = 1f;
                else if (!RandL)
                    horizontal = -1f;

               
                g_Animator.SetBool("RandL", RandL);

                g_Rigidbody2D.velocity = new Vector2(horizontal * speed , g_Rigidbody2D.velocity.y);

                g_Animator.SetFloat("MoveX", speed);
                isP = false;
            }
            //else if (c.tag == "Player2" &&
            //        Mathf.Abs(c.transform.position.x - transform.position.x) < 2 &&
            //        Mathf.Abs(c.transform.position.x - transform.position.x) >= 0)
            //{
            //    horizontal -= Time.deltaTime;
            //    g_Rigidbody2D.velocity = new Vector2(horizontal * speed, g_Rigidbody2D.velocity.y);
            //    g_Animator.SetFloat("MoveX", horizontal);
            //    isP = false;
            //}

        }
       
        if (isP)
        {
           

         
             if (Mathf.Abs(horizontal) <= 0.01)
            {
                horizontal = 0;
                times = 0.2f;
            }

            if (times > 0)
                times -= Time.deltaTime;
            else
                times = 0;

         
            g_Rigidbody2D.velocity = new Vector2(horizontal * speed, g_Rigidbody2D.velocity.y);
            g_Animator.SetFloat("MoveX", horizontal * speed);

            if (horizontal > 0)
            {
                horizontal -= Time.deltaTime + times;            
            }
               
            else if (horizontal < 0)
            {
                horizontal += Time.deltaTime + times;             
            }
          
        }
      
        Corect_flipX(horizontal);
        Corect_flipX_sprite_weapons(horizontal);
        CheckPleyar();
    }
    public void Move(bool isUp, bool isDown, bool isLeft, bool isRight, bool isDoubleR, bool isDoubleL, bool isJumping, bool isRun, bool isUsed, Touch [] t)
    {
        //if (isGrounded)
        //{
        // The Speed animator parameter is set to the absolute value of the horizontal input.

        //t[0].position.x;


        if (isDoubleR || isDoubleL)
            isRun = true;

        if (isRight)
            horizontal = 1f;
        else if (isLeft)
            horizontal = -1f;
        else if (Mathf.Abs(horizontal) <= 0.01)
        {
            horizontal = 0;
            times = 0.2f;
        }

        g_Animator.SetFloat("MoveX", horizontal);

        g_Rigidbody2D.velocity = new Vector2(horizontal * speed, g_Rigidbody2D.velocity.y);

        if (horizontal > 0)
        {

            if (times > 0)
                times -= Time.deltaTime;
            else
                times = 0;

            if (isRun)
            {
                speed = run;
            }
            else
            {
                speed = memor_speed;
            }

            RandL = true;
            g_Animator.SetBool("RandL", RandL);

            horizontal -= Time.deltaTime + times;
          
        }
        else if (horizontal < 0)
        {
            if (times > 0)
                times -= Time.deltaTime;
            else
                times = 0;

            if (isRun)
            {
                speed = run;
            }
            else
            {
                speed = memor_speed;
            }

            RandL = false;
            g_Animator.SetBool("RandL", RandL);

            horizontal += Time.deltaTime + times;
           
        }
      

        Corect_flipX(horizontal);
        Corect_flipX_sprite_weapons(horizontal);

        if (isGrounded && isJumping)
        {
            isJumping = false;
            g_Animator.SetBool("Ground", false);
            g_Rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
        else if (isJumping && countFlay<maxCountFlay)
        {
            countFlay++;
            isJumping = false;
            g_Animator.SetBool("Ground", false);
            g_Rigidbody2D.AddForce(new Vector2(0f, jump/2), ForceMode2D.Impulse);
        }

        
       

        if (isGrounded && isUsed && g_Animator.GetBool("Ground"))
        {
            isUsed = false;
            //Attack();
            Used();
        }
    }
    void HPControl()
    {
        UIHP.fillAmount = HELS;

        if (HELS > 1f)
        {
            HELS = 1f;
        }
        if (HELS < 0)
        {
            gameObject.SetActive(false);
        }
    }
    ////////////////////////////////////////////////////////////
    void CheckPleyar()
    {
        if (g_Object.Length != 0)
        {
            Transform player = g_Object[0].transform;
            if (player.position.x < transform.position.x)
            {
                direction.x = -1f;
                RandL = false;
               
            }
            else if (player.position.x > transform.position.x)
            {
                direction.x = 1f;
                RandL = true;
               
            }
        }
    }
    void Used()
    {

    }
    ////////////////////////////////////////////////////////////
    //void Attack()
    //{
    //    gameObject.GetComponent<Animator>().SetTrigger("attack");
    //}
    public override void ReciveDamage(float damag)
    {

        if (time)
        {
            HELS -= damag;
            time = false;
        }

    }
    ////////////////////////////////////////////////////////////
    void Corect_flipX_sprite_weapons(float horizontal)
    {
        if (horizontal < 0 || !RandL)
            Child.transform.position = new Vector3(transform.position.x - 1.9f, Child.transform.position.y, Child.transform.position.z);
        else
            Child.transform.position = new Vector3(transform.position.x + 1.9f, Child.transform.position.y, Child.transform.position.z);
    }
    void Corect_flipX(float horizontal)
    {
        if (horizontal < 0 || !RandL)
            sprite.flipX = !RandL;
        else
            sprite.flipX = position.x < 0;
    }
    ////////////////////////////////////////////////////////////
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
    ////////////////////////////////////////////////////////////
    void MoweAudio()
    {


        if (IsStep)
        {

            audioSource.PlayOneShot(FootSteps[Random.Range(0, FootSteps.Length)]);

            IsStep = false;
        }


        if (StopStep < 0)
        {
            StopStep = StartStopStep;
            IsStep = true;
        }
        if (StopStep > 0)
            StopStep -= Time.deltaTime;


    }
    void DownAudio()
    {        
            fallAudio.PlayOneShot(fallClip); 
    }
    void StopAudio()
    {
        audioSource.Stop();

        StopStep = StartStopStep;
        IsStep = true;
    }
   
}
