using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    [System.Serializable]
    public class LocationData
    {
        public float latitude;
        public float longitude;
        public float accuracy;
    }



    public GameObject player;
    public double minLatitude1 = 50.8236956;
    public double maxLatitude1 = 50.8237196;
    public double minLongitude1 = 3.2518905;
    public double maxLongitude1 = 3.2519178;

    public double minLatitude2;
    public double maxLatitude2;
    public double minLongitude2;
    public double maxLongitude2;

    // Reference to the UI Text component
    public TMPro.TextMeshProUGUI textComponent;
    private string previous;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    void FixedUpdate()
    {
        // Call the JS method on update, if needed
        GetDeviceLocation();
    }

    public void UpdateLocation(int ptr)
    {
        if (String.IsNullOrEmpty(previous))
        {
            // Convert the pointer to a string
            string location = Marshal.PtrToStringAnsi((IntPtr)ptr);
            Debug.Log(location);
            // Here you can update your UI or do other operations with the location data
            textComponent.text = location;
            // if the location is between the min and max latitudes and longitudes go to spawn point
            // Parse the JSON string into the LocationData class
            LocationData locationData = JsonUtility.FromJson<LocationData>(location);
            Debug.Log("Latitude: " + locationData.latitude);
            Debug.Log("Longitude: " + locationData.longitude);
            Debug.Log("Accuracy: " + locationData.accuracy);
            Debug.Log("Min Latitude: " + minLatitude1);
            Debug.Log("Max Latitude: " + maxLatitude1);
            Debug.Log("Min Longitude: " + minLongitude1);
            Debug.Log("Max Longitude: " + maxLongitude1);
            if (locationData.latitude > minLatitude1 && locationData.latitude < maxLatitude1 &&
                locationData.longitude > minLongitude1 && locationData.longitude < maxLongitude1)
            {
                Debug.Log("In bounds");
                player.transform.position = spawnPoint.position;
            }


           if (locationData.latitude > minLatitude2 && locationData.latitude < maxLatitude2 &&
                locationData.longitude > minLongitude2 && locationData.longitude < maxLongitude2)
            {
                Debug.Log("In bounds");
                player.transform.position = spawnPoint2.position;
            }
           
        }
        else
        {
            // Convert the pointer to a string
            string location = Marshal.PtrToStringAnsi((IntPtr)ptr);
            // Check if location is the same as previous
            if (location == previous)
            {
                // If it is, return
                return;
            }
            //Debug.Log("Location: " + location);
            // Here you can update your UI or do other operations with the location data
            textComponent.text = location;
        }
        
    }

    [DllImport("__Internal")]
    private static extern void GetDeviceLocation();

}
