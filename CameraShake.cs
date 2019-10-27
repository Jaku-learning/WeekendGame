using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    private static float shakeDuration = 0f;
    private static float shakeAmount = 0.07f;

    private float speed;
    private Vector3 vecZero = Vector3.zero;

    Vector3 originalPos;

    private void Awake()
    {
        if (camTransform == null)
            camTransform = transform;
    }

    public static void Shake(float timeLenght, float strenght)
    {
        shakeDuration = timeLenght;
        shakeAmount = strenght;
    }

    private void Update()
    {
        originalPos = camTransform.localPosition;

        if (shakeDuration > 0)
        {
            Vector3 newPos = originalPos + Random.insideUnitSphere * shakeAmount;
            camTransform.localPosition = Vector3.SmoothDamp(camTransform.localPosition, newPos, ref vecZero, 0.05f);

            shakeDuration -= Time.deltaTime;
            shakeDuration = Mathf.SmoothDamp(shakeDuration, 0, ref speed, 0.7f);
        }
        else
        {
            //camTransform.localPosition = originalPos;
        }

        Debug.Log(shakeDuration);
    }
}
