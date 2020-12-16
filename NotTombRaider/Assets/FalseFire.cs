using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseFire : StateMachineBehaviour
{
    private Vector3 startRotation; 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack", false);
        startRotation = animator.gameObject.transform.rotation.eulerAngles;
        Debug.Log(animator.gameObject.name + " Start: " + startRotation);
        startRotation.y = startRotation.y + 90;
        animator.gameObject.transform.rotation = Quaternion.Euler(startRotation);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //startRotation.y = startRotation.y + 0.001f;
        //animator.gameObject.transform.rotation = Quaternion.Euler(startRotation);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        startRotation.y = startRotation.y - 90;
        animator.gameObject.transform.rotation = Quaternion.Euler(startRotation);
        Debug.Log("End: " + animator.gameObject.transform.rotation);
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
