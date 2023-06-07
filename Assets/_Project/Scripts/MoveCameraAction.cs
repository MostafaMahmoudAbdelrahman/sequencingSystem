using System.Collections;
using UnityEngine;
[System.Serializable]
public class MoveCameraAction : ISequenceAction
{
    private Transform cameraTransform;
    public Vector3 targetPosition;
    public Quaternion targetRotation;
    public float duration;

    IEnumerator ISequenceAction.Execute()
    {
        cameraTransform=Camera.main.transform ;
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
