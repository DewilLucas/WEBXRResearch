using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Runtime.InteropServices;

public class GetLocationScript : MonoBehaviour
{
    // Get the location out of the GPSLocation script
    public GPSLocationScript gpsLocationScript;
    public TextMesh txt;
    void Start()
    {
        //gpsLocationScript = gameObject.AddComponent<GPSLocationScript>();
    }

    void Update()
    {
        txt.text = "Latitude: " + gpsLocationScript.latitude + ", Longitude: " + gpsLocationScript.longitude;
    }
}
