using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerNav : MonoBehaviour
{
    private NavMeshAgent agent;
    private LineRenderer line;

    public Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;

        //line.material = new Material(Shader.Find("Sprites/Default"));
    }

    void Update()
    {
        if (target != null)
        {
            // Set the destination for the NavMeshAgent
            agent.SetDestination(target.position);

            // Update the line renderer positions with corners
            Vector3[] positions = agent.path.corners.Select(corner => new Vector3(corner.x, 0, corner.z)).ToArray(); // Set y-coordinate to 0 for floor level and get all corners
            line.positionCount = positions.Length;
            line.SetPositions(positions);
        }
    }



}
