using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    PlayerInput playerInput;  // Variable for Player Input
    InputAction jumpAction;   // Variable for Jump Action
    [SerializeField] Rigidbody rb;    // Variable for the Player Rigidbody
    [SerializeField] float JumpPower; // Variable to Change to Jump Power

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();   // Read Player Input
        jumpAction = playerInput.actions.FindAction("Jump");   // Read Jump Action From Player Input
    }

    private void OnEnable()
    {
        // Let's Call a Jump Event on Action Performed
        jumpAction.performed += Jump;
    }

    private void OnDisable()
    {
        // Let's Call a Jump Event on Disable
        jumpAction.performed -= Jump;
    }

    void Jump(InputAction.CallbackContext context)
    {
        // Debug.Log("Jump"); // DEBUG Statement

        // Add an upward force to the player to make it jump
        rb.AddForce(Vector3.up * JumpPower);
    }
}
