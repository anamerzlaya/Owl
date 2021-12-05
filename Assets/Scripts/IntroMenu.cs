using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMenu : MonoBehaviour
{
    public string playGameLevel;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Debug.Log("quit!");
            Application.Quit();
        }
    }
    public void PlayGame()
    {
        Application.LoadLevel("playGameLevel");
    }

    public void QuitGame()
    {
        Debug.Log("quit!"); 
        Application.Quit();
    }
}
