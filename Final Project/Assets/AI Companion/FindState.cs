// Script for Find State Behaviour (based off of Attack State)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // For NavMesh

public class FindState : State_Controller
{
    // State Change Variable
    public FollowState stateFollow; // Next State when companion AI loses player

    // For Navigation of AI Companion
    public NavMeshAgent AIcompanion; // Companion's Nav Mesh Agent
    public Transform player; // Player's Transform
    Vector3 dest_companion; // Vector3 variable for the AI's destination
    public int time_for_clue; // Time that the companion has stopped - an override - increase difficulty
    public int timer;
    public float distance_away; // Distance away from user


    // Implementing Abstract Class
    public override State_Controller RunStateCurrent()
    {
        Debug.Log("Companion AI Current State - Find"); // DEBUG Statement

        distance_away = AIcompanion.remainingDistance;
        //Debug.Log(distance_away); // DEBUG Statement

        if ( timer < time_for_clue )
        {
            // Don't move once clue is found
            Debug.Log("Same Distance - Iterate Timer"); // DEBUG Statement
            timer = timer + 1;
            return this;
        }
        else if (timer >= time_for_clue)
        {
            // Enough time to show clue - Return the Follow State to the State Machine Controller
            timer = 0;
            return stateFollow;
        }
        else // User is Close - Show Where Clue Is
        {
            // Don't move once clue is found
            return this;
        }
    }
}
