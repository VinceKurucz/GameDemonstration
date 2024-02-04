using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_run : StateMachineBehaviour
{
    private Boss1Look look;
    Transform player;
    Rigidbody2D rb;

    public float attackRange = 3f;
    public float speed = 2.5f;

    private bool start;
    public Boss1Activate act; 


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        act = animator.GetComponent<Boss1Activate>();
        look = animator.GetComponent<Boss1Look>();

        rb = animator.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }
   

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        look.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        if(act.Start == true)
        {
            rb.MovePosition(newPos);
        }


        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Attack2");
        animator.ResetTrigger("Attack3");
    }




}
