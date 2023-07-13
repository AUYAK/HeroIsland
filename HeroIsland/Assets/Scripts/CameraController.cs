using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;
    public float smoothRotationSpeed = 0.125f;
    public float smoothPositionSpeed = 1f;
    public float currentZoom = 1f;
    public float zoomspeed = 1f;
    public float minZoom = 0.5f;
    public float maxZoom = 3f;

    private Vector3 velocity = Vector3.zero;//ref smoothDamp

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomspeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }
    private void LateUpdate()    
    {
            //Follow smoothly
        Vector3 desiredPosition = target.position + target.rotation * locationOffset * currentZoom;
    Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothPositionSpeed);
    transform.position = smoothedPosition;
        Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
    Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothRotationSpeed);
    transform.rotation = smoothedrotation;

    }
}
