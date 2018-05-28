using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float distance = 3.0f;
    public float height = 1.0f;
    public float heightDamping = 2.0f;
    public float positionDamping = 2.0f;
    public float rotationDamping = 2.0f;
    public float SmoothTime = 1.0f;
    public float maxSpeed = 5.0f;
    private Vector3 Velocity = Vector3.zero;

    private void FixedUpdate()
    {
        //Velocity = Time.deltaTime * rotationDamping);

        if (!target) return;
        float wantedHeight = target.position.y + height;
        float currentHeight = transform.position.y;
        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight,
        heightDamping * Time.deltaTime);
        // Set the position of the camera
        Vector3 wantedPosition = target.position - target.forward * distance;
        transform.position = Vector3.Lerp(transform.position, wantedPosition,
        Time.deltaTime * positionDamping);
        // Adjust the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight,
        transform.position.z);

        // Set the forward to rotate with time
        transform.forward = Vector3.SmoothDamp(transform.forward, target.forward, ref Velocity, SmoothTime, maxSpeed);
    }
}
