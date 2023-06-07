using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
[ShowOdinSerializedPropertiesInInspector]
public class SequenceController : MonoBehaviour, ISerializationCallbackReceiver, ISupportsPrefabSerialization
{
    public List<ISequenceAction> sequence = new List<ISequenceAction>();

    public SerializationData SerializationData { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Start()
    {
        PlaySequence();
    }
    public void PlaySequence()
    {
        StartCoroutine(SequenceCoroutine());
    }

    IEnumerator SequenceCoroutine()
    {
        foreach (ISequenceAction action in sequence)
        {
            yield return action.Execute();
        }
    }

    [SerializeField, HideInInspector]
    private SerializationData serializationData;
    SerializationData ISupportsPrefabSerialization.SerializationData { get { return this.serializationData; } set { this.serializationData = value; } }
    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        UnitySerializationUtility.DeserializeUnityObject(this, ref this.serializationData);
    }
    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        UnitySerializationUtility.SerializeUnityObject(this, ref this.serializationData);
        if (sequence == null)
        {
            sequence = new List<ISequenceAction>();
        }
    }
}
