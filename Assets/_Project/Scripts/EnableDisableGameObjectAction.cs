using System.Collections;
using UnityEngine;
[System.Serializable]
public class EnableDisableGameObjectAction : ISequenceAction
{
    public GameObject gameObject;
    public bool enable;
    IEnumerator ISequenceAction.Execute()
    {
        gameObject.SetActive(enable);
        yield return null;
    }
}