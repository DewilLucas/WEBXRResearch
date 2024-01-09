using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using System;
using AOT;

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

[Serializable]
public class SanityItemData
{
    public string modelUrl;
    public string description;
    public float price;
    public string name;
}

public class VirtualStoreJSBridge : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenWindow(string link);
    [DllImport("__Internal")]
    private static extern void PostItemData(string endpoint, string id, string itemName, string itemType);
    [DllImport("__Internal")]
    public static extern void GetSanityItemData(Action<string> callback);
    private static string _tryOnURL = "http://127.0.0.1:2455/";
    private static string _itemAPIEndpoint = "http://localhost:8080/item/";
    [SerializeField]
    //private ItemManager _itemManager;
    private static List<SanityItemData> parsedData = new List<SanityItemData>();
    private bool _hasLoadedData = false;

    private void Awake()
    {
       GetItemData();
    }
    public void OpenTryOn(string itemID, string itemName, string itemType)
    {
        PostItemData(_itemAPIEndpoint,itemID,itemName,itemType);
        OpenWindow(_tryOnURL);
    }

    public static void GetItemData()
    {
        GetSanityItemData(CallbackItemData);
    }

    private void Update()
    {
        if(!_hasLoadedData)
        {
            if (parsedData.Count > 0)
            {
               // _itemManager.SpawnItems(parsedData);
                _hasLoadedData = true;
            }
        }

    }

    [MonoPInvokeCallback(typeof(Action<string>))]
    public static void CallbackItemData(string itemData)
    {
        //Not ideal to use string logic to filter out json data but jsonshelper does not seem to work for the received json structure
        itemData = itemData.Remove(0,1);
        itemData = itemData.Remove(itemData.Length - 1,1);
        Debug.Log(itemData);
        string[] jsonObjects = itemData.Split(",{");
        for (int i = 0; i < jsonObjects.Length; ++i)
        {
            if(i != 0)
            {
                jsonObjects[i] = "{" + jsonObjects[i];
            }
            Debug.Log(jsonObjects[i]);
            SanityItemData parsedObject = JsonUtility.FromJson<SanityItemData>(jsonObjects[i]);
            parsedData.Add(parsedObject);
        }
    }
}
