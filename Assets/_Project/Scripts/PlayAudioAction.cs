using System.Collections;
using UnityEngine;
[System.Serializable]
public class PlayAudioAction : ISequenceAction
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool waitForCompletion;

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