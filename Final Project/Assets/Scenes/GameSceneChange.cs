using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For changing scenes

public class GameSceneChange : MonoBehaviour
{
    public string nameLevel; // Scene Need to Load After trigerring the event

    // Function called when triggered
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "PlayerCamera")
        {
            Debug.Log("Player is in the Collision Zone"); // DEBUG Statement
            // Load whatever scene is given
            SceneManager.LoadScene(nameLevel);
        }
    }
}
