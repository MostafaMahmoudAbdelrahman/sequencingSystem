using System.Collections;
using UnityEngine;
[System.Serializable]
public class PlayAudioAction : ISequenceAction
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    private bool waitForCompletion;

    public PlayAudioAction(AudioSource audioSrc, AudioClip clip, bool wait)
    {
        audioSource = audioSrc;
        audioClip = clip;
        waitForCompletion = wait;
    }

   IEnumerator ISequenceAction.Execute()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        if (waitForCompletion)
        {
            // Wait for the audio clip to finish playing
            yield return new WaitForSeconds(audioClip.length);
        }
    }
}