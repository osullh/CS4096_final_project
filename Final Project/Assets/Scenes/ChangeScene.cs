using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For changing scenes
public class ChangeScene : MonoBehaviour
{
    public string nameLevel; // Scene Need to Load After Clicking the button

    // Function that gets called when button gets clicked
    public void SceneLoad()
    {
        // Load whatever scene is given
        SceneManager.LoadScene(nameLevel);
    }
}
