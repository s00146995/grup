using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public float timeElapsed;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 202f)    // If Intro Cutscene finishes
        {
            SceneManager.LoadScene("Valley of Mines");  // Move to next scene
        }

        if (Input.GetKeyDown("escape") || Input.GetKeyDown("space"))    // Skip statement
        {
            SceneManager.LoadScene("Valley of Mines");
        }
    }
}
