using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    // Add a variableto control the speed
    [SerializeField] float speed = 5;

    // Variable for the Player Rigidbody
    Rigidbody rb;

    private void Awake() 
    {
        // Get Player Input
        playerInput = GetComponent<PlayerInput>();
        // Read Move Action from the Action Map
        moveAction = playerInput.actions.FindAction("Move");
    }

    void Start() // Start is called before the first frame update
    {
        // Rigidbody in the Start
        rb = GetComponent<Rigidbody>();
    }

    void Update() // Update is called once per frame
    {
        MovePlayer();
    }

    void MovePlayer() // Function to Move
    {
        // Debug.Log(moveAction.ReadValue<Vector3>()); // Read the vector two values from the action map

        Vector3 val = moveAction.ReadValue<Vector2>(); // Read the Value to a Variable

        // Make Sudden Stop (Velcoity = 0) if there's No Input
        if (val == Vector3.zero)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        Vector3 direction = new Vector3(val.x, 0, val.y);
        Vector3 velocity = direction * speed * Time.deltaTime;   // Need to keep the y velocity as it is
        velocity.y = rb.velocity.y;   // Keep the y velocity same as the rigidbody velocity

        // Add a Relative Force
        rb.AddRelativeForce(velocity);
    }
}
