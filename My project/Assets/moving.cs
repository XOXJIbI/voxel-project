using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform obj;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;

    void Start()
    {

    }


    void LateUpdate()
    {
        Vector3 currentPosition = mainCamera.position;
        //Vector3 targetPosition = currentPosition + new Vector3(joystick.Horizontal, 0, joystick.ertical);
        mainCamera.position = Vector3.SmoothDamp(currentPosition, obj.position + offset, ref velocity, smoothTime);
    }
}
