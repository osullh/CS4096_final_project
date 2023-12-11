using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickUp : MonoBehaviour
{
    public GameObject crosshair1; // Regular Crosshair
    public GameObject crosshair2; // Crosshair that appears when looking at an object
    public Transform objTransform; // Object's Transform 
    public Transform cameraTrans; // Player's Camera Transform 
    public bool interactable; // Determines whteher or not player is looking at the object
    public bool pickedup; // Determines whether or not the object is picked up
    public Rigidbody objRigidBody; // The object's rigidbody
    public float throwAmount; // Distance object can be thrown

    void OnTriggerStay(Collider other)
    {
        // If player is looking at object - interactable and crosshair changes
        if (other.CompareTag("PlayerCamera"))
        {
            Debug.Log("Player is Looking at Object"); // DEBUG STATEMENT
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If player is not looking at object - not interactable and crosshair changes
        if (other.CompareTag("PlayerCamera"))
        {
            Debug.Log("Player is Not Looking at Object"); // DEBUG STATEMENT
            crosshair1.SetActive(true);
            crosshair2.SetActive(false);
            interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable == true)
        {
            // If Player Holds Q, the object will be picked up
            if (Input.GetKeyDown(KeyCode.Q)) 
            {
                Debug.Log("Pressed Q Key"); // DEBUG STATEMENT
                objTransform.parent = cameraTrans;
                objRigidBody.useGravity = false;
                pickedup = true;
            }
            // If Player Lets Go of Q, the object will be dropped
            if (Input.GetKeyUp(KeyCode.Q))
            {
                Debug.Log("Let Go of Q Key"); // DEBUG STATEMENT
                objTransform.parent = null;
                objRigidBody.useGravity = true;
                pickedup = false;
            }
            if(pickedup == true)
            {
                // If Player Presses E, the object will be thrown
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pressed E Key"); // DEBUG STATEMENT
                    objTransform.parent = null;
                    objRigidBody.useGravity = true;
                    objRigidBody.velocity = cameraTrans.forward * throwAmount * Time.deltaTime;
                    pickedup = false;
                }
            }
        }
        
    }
}
