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
    public double minLatitude;
    public double maxLatitude;
    public double minLongitude;
    public double maxLongitude;
    // Reference to the UI Text component
    public TMPro.TextMeshProUGUI textComponent;
    private string previous;
    public Transform spawnPoint;
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
            Debug.Log("Min Latitude: " + minLatitude);
            Debug.Log("Max Latitude: " + maxLatitude);
            Debug.Log("Min Longitude: " + minLongitude);
            Debug.Log("Max Longitude: " + maxLongitude);
            if (locationData.latitude > minLatitude && locationData.latitude < maxLatitude &&
                locationData.longitude > minLongitude && locationData.longitude < maxLongitude)
            {
                Debug.Log("In bounds");
                player.transform.position = spawnPoint.position;
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
