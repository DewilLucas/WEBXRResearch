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

    [System.Serializable]
    public class LocationBounds
    {
        public string namePoint;
        public double minLatitude;
        public double maxLatitude;
        public double minLongitude;
        public double maxLongitude;
        public Transform spawnPoint;
    }

    public GameObject player;


    // Array to store multiple location bounds
    public LocationBounds[] locationBoundsArray;


    // Reference to the UI Text component
    public TMPro.TextMeshProUGUI textComponent;
    private string previous;
    public TMPro.TextMeshProUGUI textComponentPosition;
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


            // Check if the location is within any of the specified bounds
            foreach (var bounds in locationBoundsArray)
            {
                if (IsInBounds(locationData.latitude, locationData.longitude, bounds))
                {
                    Debug.Log("In bounds");
                    player.transform.position = bounds.spawnPoint.position;
                    textComponentPosition.text = bounds.namePoint;
                    break; // Exit the loop if the location is within any range
                }
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
    // Check if the location is within the specified bounds
    private bool IsInBounds(float latitude, float longitude, LocationBounds bounds)
    {
        return latitude > bounds.minLatitude && latitude < bounds.maxLatitude &&
               longitude > bounds.minLongitude && longitude < bounds.maxLongitude;
    }
    [DllImport("__Internal")]
    private static extern void GetDeviceLocation();

}
