using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Next_Level_Button_Script : MonoBehaviour
{
    public void Next_Level()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Recycle scenes if we run out of scenes 
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // Load the first scene
        }

        // else, go to next scene 
        SceneManager.LoadScene(nextSceneIndex);
    }
}
