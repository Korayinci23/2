using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class ChaseCharacter : MonoBehaviour
{
    public Transform player; 

    public float moveSpeed = 5f; 
    public float rotationSpeed = 5f; 
    public float chaseRange = 10f; 
    public float deathRange = 1f; 

    private void Update()
    {
        
        float distance = Vector3.Distance(player.position, transform.position);

        ChasePlayer(distance); 
    }

    private void PlayerDeath(float distance)
    {
        
        if (distance <= deathRange)
        {
            SceneManager.LoadScene("DeadScene");
        }
    }

    private void ChasePlayer(float distance)
    {
        
        if (distance < chaseRange)
        {
            
            Vector3 direction = (player.position - transform.position).normalized;

           
            transform.position += direction * moveSpeed * Time.deltaTime;

            
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            
        }
        
    }
}