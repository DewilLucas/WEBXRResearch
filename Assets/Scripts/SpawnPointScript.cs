using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public GetSpawningPointScript spawningPointScript;

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (spawningPointScript != null)
        {
            // Get data
            GetSpawningPointScript.LocationPosition data = spawningPointScript.data;
            if (data != null)
            {
                // Get parameters from the url
                string id = data.Parameters["id"];
                switch (id.ToLower())
                {
                    case "wc":
                        if (spawnPoint != null)
                        {
                            transform.position = spawnPoint.position;
                        }
                        break;
                }
            }
        }
    }
}
