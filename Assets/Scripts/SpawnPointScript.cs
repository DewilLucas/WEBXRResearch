using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public GetSpawningPointScript spawningPointScript;

    public Transform[] spawnPoints;

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
                        if (spawnPoints[0] != null)
                        {
                            transform.position = spawnPoints[0].position;
                        }
                        break;
                    case "locaal1":
                        if (spawnPoints[1] != null)
                        {
                            transform.position = spawnPoints[1].position;
                        }
                        break;
                }
            }
        }
    }
}
