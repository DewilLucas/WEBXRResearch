using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TextChanger : MonoBehaviour
{

    // Reference to the UI Text component
    public TMPro.TextMeshProUGUI textComponent;

    void Update()
    {
        // Call the JS method on update, if needed
        GetDeviceLocation();
    }

    public void UpdateLocation(int ptr)
    {
        // Convert the pointer to a string
        string location = Marshal.PtrToStringAnsi((IntPtr)ptr);
        Debug.Log("Location: " + location);
        // Here you can update your UI or do other operations with the location data
        textComponent.text = location;
    }

    [DllImport("__Internal")]
    private static extern void GetDeviceLocation();

}
