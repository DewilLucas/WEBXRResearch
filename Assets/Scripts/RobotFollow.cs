using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotFollow : MonoBehaviour
{

    public Transform player; // Reference to the player's transform
    public LineRenderer line; // Reference to the LineRenderer component
    public float distanceInFront = 2.0f; // The distance in front of the player where the robot should stay

    private NavMeshAgent agent; // Reference to the NavMeshAgent component
    private int currentCorner = 0; // The current corner the robot is moving towards
    private Vector3[] corners; // The corners of the path

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Get the corners from the LineRenderer
        corners = new Vector3[line.positionCount];
        line.GetPositions(corners);

        // If the robot has reached the current corner, move to the next one
        if (Vector3.Distance(transform.position, corners[currentCorner]) < agent.stoppingDistance)
        {
            currentCorner++;
        }

        // If the robot has not reached the last corner, set the destination to the current corner
        if (currentCorner < corners.Length)
        {
            agent.SetDestination(corners[currentCorner]);
        }
        // If the robot has reached the last corner, stop
        else
        {
            agent.SetDestination(transform.position);
        }

        // Make the robot stay in front of the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 positionInFront = player.position + directionToPlayer * distanceInFront;
        agent.SetDestination(positionInFront);
    }
}
