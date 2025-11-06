using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType type)
    {
        switch (type)
        {
            case AnimationType.RUN:
                animator.SetBool("IsRunning", true);
                break;

            case AnimationType.IDLE:
                animator.SetBool("IsRunning", false);
                break;

            case AnimationType.DEAD:
                animator.SetTrigger("Dead");
                break;
        }
    }
}
