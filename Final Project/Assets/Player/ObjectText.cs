using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For changing scenes

public class ObjectText : MonoBehaviour
{
    public GameObject textObj;

    void Start()
    {
        textObj.SetActive(false);
    }
    // Function called when triggered
    void OnTriggerEnter(Collider player)
    {
        Debug.Log("Text Box Should Be Triggered"); //  DEBUG Statement
        Debug.Log(player.gameObject.tag);
        if(player.gameObject.tag == "PlayerCamera")
        {
            textObj.SetActive(true);
            StartCoroutine("WaitForFiveSeconds");
        }
    }

    IEnumerator WaitForFiveSeconds()
    {
        yield return new WaitForSeconds(5);
        textObj.SetActive(false);
        //Destroy(textObj);
    }
}
