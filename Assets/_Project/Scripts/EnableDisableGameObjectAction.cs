using System.Collections;
using UnityEngine;
[System.Serializable]
public class EnableDisableGameObjectAction : ISequenceAction
{
    private GameObject gameObject;
    private bool enable;

    public EnableDisableGameObjectAction(GameObject obj, bool en)
    {
        gameObject = obj;
        enable = en;
    }

    IEnumerator ISequenceAction.Execute()
    {
        gameObject.SetActive(enable);
        yield return null;
    }
}