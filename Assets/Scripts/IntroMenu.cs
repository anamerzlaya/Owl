using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        AudioManager.instance.PlaySFX(8);
        //Application.LoadLevel("playGameLevel");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("quit!"); 
        Application.Quit();
    }
}
