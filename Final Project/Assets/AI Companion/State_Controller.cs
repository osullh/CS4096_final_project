// State Controller for AI Companion
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract Class: Only Inhereiting From It
public abstract class State_Controller : MonoBehaviour
{
    // Function that returns a state
    public abstract State_Controller RunStateCurrent();
}
