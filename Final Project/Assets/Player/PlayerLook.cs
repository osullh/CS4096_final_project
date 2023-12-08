using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    PlayerInput playerInput;  // Variable for Player Input
    InputAction lookAction;   // Variable for Look Action

    [SerializeField] Transform cameraHolder;  // Variable for Camera Holder
    [SerializeField] Vector3 currentRotation;  // Variable for Current Rotation
    [SerializeField] Rigidbody rb;  // Variable for Player Rigidbody
    [SerializeField] float clampValue; // Variable for the Clamp Angle

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();  // read player input
        lookAction = playerInput.actions.FindAction("Look");  // read look action
    }

    private void Start()
    {
        // Initialize the current rotation in the start
        currentRotation = transform.eulerAngles;
    }

    private void OnEnable()
    {
        lookAction.performed += Look; // call it on performed
    }

    private void OnDisable()
    {
        lookAction.performed -= Look; // remove event on disable
    }

    void Look(InputAction.CallbackContext context)
    {
        if (Input.GetMouseButton(0)) // Checks to see if Left Button is Clicked
        {
            // Debug.Log("Left Button Has Been Clicked - Move Camera"); // DEBUG STATEMENT

            // Read the Delta From the Look Action
            Vector3 mouseDelta = lookAction.ReadValue<Vector2>();

            // Add Mouse Delta x to the Current Rotation
            currentRotation.x += mouseDelta.x;

            // Subtract Mouse Delta y from the Current Rotation
            currentRotation.y -= mouseDelta.y;

            // Apply Clamp to the Y-Axis of Current Rotation
            currentRotation.y = Mathf.Clamp(currentRotation.y, -clampValue, clampValue);

            // Apply Current Rotation to the Camer Holder - apply in x and y axis
            cameraHolder.rotation = Quaternion.Euler(new Vector3(currentRotation.y, cameraHolder.rotation.eulerAngles.y, 0));

            // Add y-axis rotation to player rigidbody
            rb.rotation = Quaternion.Euler(new Vector3(0, currentRotation.x, 0));
        }
    }
}
