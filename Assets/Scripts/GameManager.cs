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

    private ScoreManager theScoreManager;

    public FinalMenu theFinalScreen;

    // Start is called before the first frame update
    void Start()
    {
        obstacleStartPoint = obstacleGenerator.position;
        grassStartPoint = grassGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        //StartCoroutine("RestartGameCo");
        theScoreManager.scoreIncreasing = false;

        StartCoroutine("RestartGameCoroutine");

        //theFinalScreen.gameObject.SetActive(true);
        //theFinalScreen.GetComponent<Animator>().SetBool("StartAnim", true);
    }
    public void Reset()
    {
        theFinalScreen.gameObject.SetActive(false);
        theFinalScreen.GetComponent<Animator>().SetBool("StartAnim", false);

        obstacleList = FindObjectsOfType<ObstacleDestroyer>();
        for (int i = 0; i < obstacleList.Length; i++)
        {
            obstacleList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        obstacleGenerator.position = obstacleStartPoint;
        grassGenerator.position = grassStartPoint;
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

    }
    public IEnumerator RestartGameCoroutine()
    {
        thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", true);
        yield return new WaitForSeconds(1.0f);
        thePlayer.gameObject.SetActive(false);
        thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", false);

        theFinalScreen.gameObject.SetActive(true);
        theFinalScreen.GetComponent<Animator>().SetBool("StartAnim", true);
    }
    
    public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
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
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }
}
