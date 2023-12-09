using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followUser : MonoBehaviour
{
    public NavMeshAgent companion_ai; // Companion's Nav Mesh Agent
    public Transform player; // Player's Transform
    Vector3 companion_destination; // Vector3 variable for the AI's destination
    public string companion_ai_state; // Companion AI State (FSM)

    private void Update()
    {
        // AI companion's destination will be equal to the player (detective's) current position - following behavior
        companion_destination = player.position;
        companion_ai.destination = companion_destination;

        // If the companion's remaining distance is <= stopping distance - FSM will enter idle state
        if(companion_ai.remainingDistance <= companion_ai.stoppingDistance)
        {
            //Debug.Log("Companion AI - Entering Idle State"); // DEBUG Statement
            companion_ai_state = "idle";
            // add animation change here - future implementation
        }
        else
        {
            //Debug.Log("Companion AI - Entering Follow State"); // DEBUG Statement
            companion_ai_state = "follow";
            // add animation change here - future implementation
        }
    }
}
