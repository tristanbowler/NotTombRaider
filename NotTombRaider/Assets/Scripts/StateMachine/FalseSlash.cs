using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseSlash : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    public float Wait;
    public float start;
    bool thrown = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack", false);
        if (animator.gameObject.GetComponent<MacheteController>())
        {
            animator.gameObject.GetComponent<MacheteController>().hitController.collider.enabled = true;
            thrown = true;
        }
        else
        {
            thrown = false;
        }
        start = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!thrown)
        {
            float timeElapsed = Time.time - start;
            if (timeElapsed >= Wait)
            {
                if (animator.gameObject.GetComponent<QueenController>())
                {
                    animator.gameObject.GetComponent<QueenController>().StartBomb();
                    thrown = true;
                }
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (animator.gameObject.GetComponent<MacheteController>())
        {
            Debug.Log("Turning off collider on " + animator.gameObject.name);
            animator.gameObject.GetComponent<MacheteController>().hitController.collider.enabled = false;
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
