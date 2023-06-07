using System.Collections;
using UnityEngine;
[System.Serializable]
public class PlayAnimationAction : ISequenceAction
{
    public Animator animator;
    public string triggerName;
    public bool waitForCompletion;

    IEnumerator ISequenceAction.Execute()
    {
        animator.SetTrigger(triggerName);
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