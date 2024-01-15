using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ARCamera; // Assign your AR Camera in the inspector
    private float initialHeight; // This will store the initial height of the camera

    void Start()
    {
        initialHeight = ARCamera.transform.position.y; // Store the initial height of the camera
    }

    void Update()
    {
        Vector3 cameraPosition = ARCamera.transform.position;
        cameraPosition.y = initialHeight; // Set the y-coordinate to the initial height
        ARCamera.transform.position = cameraPosition;
    }
}
