using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    //public PlayerController thePlayer;
    public GameObject thePlayer;
    private Vector3 lastPlayerPos;
    private float distanceToMove;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lastPlayerPos = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move the camera to follow the player
        distanceToMove = thePlayer.transform.position.x - lastPlayerPos.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPos = thePlayer.transform.position;

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Debug.Log("quit!");
            Application.Quit();
        }
    }
}
