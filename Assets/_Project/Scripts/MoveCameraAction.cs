using System.Collections;
using UnityEngine;
[System.Serializable]
public class MoveCameraAction : ISequenceAction
{
    private Transform cameraTransform;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float duration;

    public MoveCameraAction(Transform camTransform, Vector3 targetPos, Quaternion targetRot, float dur)
    {
        cameraTransform = camTransform;
        targetPosition = targetPos;
        targetRotation = targetRot;
        duration = dur;
    }
    IEnumerator ISequenceAction.Execute()
    {
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            cameraTransform.position = Vector3.Lerp(startPosition, targetPosition, t);
            cameraTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cameraTransform.position = targetPosition;
        cameraTransform.rotation = targetRotation;
    }

}
