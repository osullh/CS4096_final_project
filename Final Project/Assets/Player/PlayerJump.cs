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
    // public bool isGrounded = false;   // Variable to Check if Player is Grounded

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();   // Read Player Input
        jumpAction = playerInput.actions.FindAction("Jump");   // Read Jump Action From Player Input
    }

    private void OnEnable()
    {
        // Let's Call a Jump Event on Action Performed
        // isGrounded = true;
        jumpAction.performed += Jump;
    }

    private void OnDisable()
    {
        // Let's Call a Jump Event on Disable
        jumpAction.performed -= Jump;
    }

    void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump Action Called"); // DEBUG Statement
        rb.AddForce(Vector3.up * JumpPower);

//        // Check to see if Player is Grouded - Will Prevent Double Jump
//
//        // If Player is Grouded -> Jump
//        if (isGrounded == true)
//        {
//            Debug.Log("Grounded - Let's Jump"); // DEBUG Statement
//
//            // Add an upward force to the player to make it jump
//            rb.AddForce(Vector3.up * JumpPower);
//            isGrounded = false;
//        }
//        // If Player is Not Grouded -> Return to Ground
//        else
//        {
//            Debug.Log("Grounded - Let's Jump"); // DEBUG Statement
//
//            // Add an downward force to the player so they go down
//            rb.AddForce(Vector3.down * JumpPower);
//            isGrounded = true;
//        }
    }
}
