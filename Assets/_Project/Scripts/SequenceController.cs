using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SequenceController : MonoBehaviour
{
    public List<ISequenceAction> sequence = new List<ISequenceAction>();
    public void PlaySequence()
    {
        StartCoroutine(SequenceCoroutine());
    }

    IEnumerator SequenceCoroutine()
    {
        foreach (ISequenceAction action in sequence)
        {
            action.Execute();
            yield return null;
        }
    }

}
