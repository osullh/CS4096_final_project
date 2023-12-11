// Script for Idle State Behaviour (not following user)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // For NavMesh

public class IdleState : State_Controller
{
    // State Change Variables
    public FollowState stateFollow; // Next State when companion AI loses player
    public FindState stateFind; // Next State when companion AI is close to clue
    public bool ClueinRange; // Is the Clue Close Enough to Find

    // For Navigation of AI Companion
    public NavMeshAgent AIcompanion; // Companion's Nav Mesh Agent
    public Transform player; // Player's Transform
    Vector3 dest_companion; // Vector3 variable for the AI's destination

    // Variables for Finding Clues
    public GameObject[] AllClues; // Game Object storing all the clues
    public GameObject NearestClue; // Game Object for the nearest clue
    float distance; // Variable storing the distance to clue
    public float nearestDistance; // Distance that the companion needs to be before "finding clue"
    public bool FoundClue; // If Companion Found Clue, Stop

    // Implementing Abstract Class
    public override State_Controller RunStateCurrent()
    {
        Debug.Log("Companion AI Current State - Idle"); // DEBUG Statement

        // AI companion's destination will be equal to the player (detective's) current position - following behavior
        dest_companion = player.position;
        AIcompanion.destination = dest_companion;

        // Finding Clues - 
        AllClues = GameObject.FindGameObjectsWithTag("Clues"); // Can find all objects with "Clues" Type
        for (int i = 0; i < AllClues.Length; i++)
        {
            // Measure distance of any object
            distance = Vector3.Distance(this.transform.position, AllClues[i].transform.position);
            if (distance < nearestDistance && FoundClue == false)
            {
                NearestClue = AllClues[i];
                // Debug.LogFormat("Nearest Clue is", NearestClue, "and is this far away", distance); // DEBUG Statement
                FoundClue = true;
            }
        }

        if (FoundClue)
        {
            // If Clue is In Range - Return the Find State to the State Machine Controller
            FoundClue = false;
            distance = 0;
            return stateFind;
        }
        else if (AIcompanion.remainingDistance >= AIcompanion.stoppingDistance)
        {
            // If User is not close - Return the Follow State to the State Machine Controller
            FoundClue = false;
            distance = 0;
            return stateFollow;
        }
        else
        {
            return this;
        }
    }
}
