using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    public State_Controller stateCurrent;

    // Update is called once per frame
    void Update()
    {
        RunningStateMachine();
    }

    // Function for AI State Machine
    private void RunningStateMachine()
    {
        //Debug.Log("Companion AI - Running State Machine"); // DEBUG Statement

        // If variable is not null, run the current state, otherwise ignore
        State_Controller stateNext = stateCurrent?.RunStateCurrent();

        if (stateNext != null)
        {
            // If not null, switch to next state
            SwitchToStateNext(stateNext);
        }
    }

    // Function to Switch to the Next State
    private void SwitchToStateNext(State_Controller stateNext)
    {
        // Switch the current state to the passed state (next state)
        stateCurrent = stateNext;
        
        // Debug.Log("Companion AI - Entering Next State"); // DEBUG Statement
    }
}
