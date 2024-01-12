using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerNav : MonoBehaviour
{
    private LineRenderer line;
    public Transform target;
    public GameObject floor;
    public GameObject Stair;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
    }

    void Update()
    {
        // Calculate the path without using NavMeshAgent
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);

        // Update the line renderer positions with corners
        Vector3[] positions = path.corners.ToArray();

        // Adjust line to avoid obstacles
        for (int i = 1; i < positions.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Linecast(positions[i - 1], positions[i], out hit))
            {
                positions[i] = hit.point;
                line.positionCount = i + 1;
                break; // Stop checking further, as we hit an obstacle
            }
        }

        // Set the positions to the LineRenderer
        line.positionCount = positions.Length;
        line.SetPositions(positions);
    }



}
