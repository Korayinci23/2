using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public List<Transform> waypoints; // List of waypoints for the enemy to patrol
    public float speed = 2.0f; // Enemy movement speed
    public float waitTime = 1.0f; // Time to wait at each waypoint
    public float rotationSpeed = 5.0f; // Speed at which the enemy rotates to face the next waypoint

    public int currentWaypointIndex = 0;
    public float waitTimer;
    public bool isAlerted = false;

    void Start()
    {
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position;
            waitTimer = waitTime;
        }
        else
        {
            Debug.LogError("No waypoints set for enemy patrol.");
        }
    }

    void Update()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        if (isAlerted)
        {
            MoveTowardsPlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        float step = speed * Time.deltaTime;

        // Move towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

        // Rotate to face the waypoint
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if the enemy has reached the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (waitTimer <= 0)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
                waitTimer = waitTime;
            }
            else
            {
                waitTimer -= Time.deltaTime;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float step = speed * Time.deltaTime;

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

        // Rotate to face the player
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject == player)
        {
            isAlerted = true;
        }
    }
}


