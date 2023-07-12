using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;
    public float smoothSpeed = 0.125f;
    public float currentZoom = 1f;
    public float zoomspeed = 1f;
    public float minZoom = 0.5f;
    public float maxZoom = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() 
    {
        //Zoom by scroll
        currentZoom -= Input.GetAxis("Mouse ScrollWheel")*zoomspeed; 
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        //Follow smoothly
        Vector3 desiredPosition = target.position + target.rotation * locationOffset*currentZoom;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;

    }
}
