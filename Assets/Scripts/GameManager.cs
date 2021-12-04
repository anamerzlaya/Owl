using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform obstacleGenerator;
    private Vector3 obstacleStartPoint;
    public Transform grassGenerator;
    private Vector3 grassStartPoint;
    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private ObstacleDestroyer[] obstacleList;

    // Start is called before the first frame update
    void Start()
    {
        obstacleStartPoint = obstacleGenerator.position;
        grassStartPoint = grassGenerator.position;
        playerStartPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        obstacleList = FindObjectsOfType<ObstacleDestroyer>();
        for(int i=0; i<obstacleList.Length; i++)
        {
            obstacleList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        obstacleGenerator.position = obstacleStartPoint;
        grassGenerator.position = grassStartPoint;
        thePlayer.gameObject.SetActive(true);
    }
}
