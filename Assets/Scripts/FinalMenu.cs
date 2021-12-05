using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenu : MonoBehaviour
{
    public void RestartGame()
    {
        AudioManager.instance.PlaySFX(8);
        FindObjectOfType<GameManager>().Reset();
    }
}
