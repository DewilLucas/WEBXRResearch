using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class GetSpawningPointScript : MonoBehaviour
{
    [System.Serializable]
    public class LocationPosition
    {
        public string URL;
        public NameValueCollection Parameters; // NameValueCollection to store URL parameters
    }

    public LocationPosition data;
    private string previous;
    [DllImport("__Internal")]
    private static extern string GetCurrentUrl();

    void Start()
    {
        GetCurrentUrl();
    }
    void UpdateLocationQR(int ptr)
    {
        if (String.IsNullOrEmpty(previous))
        {
            string location = Marshal.PtrToStringAnsi((IntPtr)ptr);
            data = JsonUtility.FromJson<LocationPosition>(location);
            // Get parameters from the url


            if (data != null)
            {
                Debug.Log("Received URL: " + data.URL);
                // Extract parameters using System.Uri
                Uri uri = new Uri(data.URL);
                data.Parameters = System.Web.HttpUtility.ParseQueryString(uri.Query);
                // Log parameters
                foreach (string key in data.Parameters.AllKeys)
                {
                    Debug.Log("Parameter: " + key + ", Value: " + data.Parameters[key]);
                }
                previous = location;
            }
            else
            {
                Debug.LogError("Failed to deserialize JSON data.");
            }
        }
    }
}
