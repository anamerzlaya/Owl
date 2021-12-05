using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenu : MonoBehaviour
{
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }
}
