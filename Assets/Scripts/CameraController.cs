using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ARCamera; // Assign your AR Camera in the inspector
    public float height = 1.0f; // Set the height you want for the camera

    void Update()
    {
        Vector3 cameraPosition = ARCamera.transform.position;
        cameraPosition.y = height;
        ARCamera.transform.position = cameraPosition;
    }
}
