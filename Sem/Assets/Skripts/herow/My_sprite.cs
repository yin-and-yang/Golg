using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class My_sprite : MonoBehaviour {
    public Transform target;
    public float yOffset;

    private Animator animator;
    public NavMeshAgent myAgent;

    public Transform Camera;

    private SpriteRenderer sprite;
    // Use this for initialization
    void Start () {
		
	}
    private void Awake()
    {

        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
      

    }

    void Mowe()
    {
        if (myAgent.velocity.x < 0 && myAgent.velocity.z > 0)
        {
            animator.SetFloat("Direction", -1);//x
            animator.SetFloat("Speed", 1);//z
        }
        else if (myAgent.velocity.x == 0 && myAgent.velocity.z > 0)
        {
            animator.SetFloat("Direction", 0);
            animator.SetFloat("Speed", 1);
        }
        else if (myAgent.velocity.x > 0 && myAgent.velocity.z > 0)
        {
            animator.SetFloat("Direction", 1);
            animator.SetFloat("Speed", 1);
        }
        else if (myAgent.velocity.x > 0 && myAgent.velocity.z == 0)
        {
            animator.SetFloat("Direction", 1);
            animator.SetFloat("Speed", 0);
        }
        else if (myAgent.velocity.x > 0 && myAgent.velocity.z < 0)
        {
            animator.SetFloat("Direction", 1);
            animator.SetFloat("Speed", -1);
        }
        else if (myAgent.velocity.x == 0 && myAgent.velocity.z < 0)
        {
            animator.SetFloat("Direction", 0);
            animator.SetFloat("Speed", -1);
        }
        else if (myAgent.velocity.x < 0 && myAgent.velocity.z < 0)
        {
            animator.SetFloat("Direction", -1);
            animator.SetFloat("Speed", -1);
        }
        else if (myAgent.velocity.x < 0 && myAgent.velocity.z == 0)
        {
            animator.SetFloat("Direction", -1);
            animator.SetFloat("Speed", 0);
        }
        else if (myAgent.velocity.x == 0 && myAgent.velocity.z == 0)
        {
            animator.SetFloat("Direction", 0);
            animator.SetFloat("Speed", 0);
        }

        transform.localPosition = new Vector3(target.localPosition.x, transform.localPosition.y + yOffset, target.localPosition.z);

    }


    // Update is called once per frame
    void Update () {

        
        Mowe();
        transform.rotation = Camera.rotation;

        Corect_flipX(myAgent.velocity.x);


    }

    void Corect_flipX(float horizontal)
    {
        if (horizontal < 0 )
            sprite.flipX = false;
        else
            sprite.flipX = true;
    }
}
