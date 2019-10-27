using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    private Vector3 targetPos;
    private Vector3 currentVel;
    [SerializeField] private float smoothFactor;
    [SerializeField] private float maxFollowSpeed;

    private void FixedUpdate()
    {
        if (player == null)
        {
            transform.position = targetPos;
        } else
        {
            targetPos.x = player.position.x;
            targetPos.y = player.position.y;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos - new Vector3(0, 0, 10), ref currentVel, smoothFactor, maxFollowSpeed, Time.deltaTime);
        }
    }
}
