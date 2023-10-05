using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float sensitivity = 5;
    public Vector3 rotation = new Vector3(-30, 160, 0);
    public Transform rotationalAxis;

    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotation = new Vector3(Mathf.Clamp(rotation.x + Input.GetAxis("Mouse Y") * sensitivity, -80, 80), rotation.y + Input.GetAxis("Mouse X") * sensitivity, 0);
        }

        transform.eulerAngles = new Vector3(0, rotation.y, 0);
        rotationalAxis.localEulerAngles = new Vector3(rotation.x, 0, 0);


        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
    }
}