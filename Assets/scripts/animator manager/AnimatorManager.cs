using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimationSetup> animatorSetups;
    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType type)
    {
        /*animatorSetups.ForEach(i =>
        {
            if(i.type == type)
            {
                animator.SetTrigger(i.trigger);
            }
        });*/

        foreach(var animation in animatorSetups)
        {
            if(animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }
}


[System.Serializable]
public class AnimationSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
}
