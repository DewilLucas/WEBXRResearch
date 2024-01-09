using System;
using UnityEngine;
using System.Runtime.InteropServices;
using TMPro;

public class GPSLocationScript : MonoBehaviour
{
    public static string Lat;
    public static string Lon;

    public string longitude;
    public string latitude;

    [DllImport("__Internal")]
    private static extern void GetLocation();

    [AOT.MonoPInvokeCallback(typeof(Action<string, string>))]
    private static void ReceiveLocation(string lat, string lon)
    {
        Debug.Log("Latitude: " + lat + ", Longitude: " + lon);
        Lat = lat;
        Lon = lon;
    }

    [DllImport("__Internal")]
    private static extern void RegisterFunction(string funcName);

    void Start()
    {
        // Register the ReceiveLocation function in JavaScript
        RegisterFunction("ReceiveLocation");

        GetLocation();
        longitude = Lon;
        latitude = Lat;
    }

}
