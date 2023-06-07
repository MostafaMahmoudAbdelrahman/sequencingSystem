using System.Collections;
using UnityEngine;
[System.Serializable]
public class PlayAnimationAction : ISequenceAction
{
    private Animator animator;
    private string animationName;
    private bool waitForCompletion;

    public PlayAnimationAction(Animator anim, string animName, bool wait)
    {
        animator = anim;
        animationName = animName;
        waitForCompletion = wait;
    }
    IEnumerator ISequenceAction.Execute()
    {
        animator.Play(animationName);
        if (waitForCompletion)
        {
            // Wait for the animation to finish playing
            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                yield return null;
            }
        }
    }
}