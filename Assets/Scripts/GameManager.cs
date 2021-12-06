using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform obstacleGenerator;
    private Vector3 obstacleStartPoint;
    public Transform obstacleGeneratorAbove;
    private Vector3 obstacleStartPointAbove;
    public Transform grassGenerator;
    private Vector3 grassStartPoint;
    public Transform goodBugGenerator;
    private Vector3 goodBugStartPoint;
   public Transform badBugGenerator;
    private Vector3 badBugStartPoint;
    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private ObstacleDestroyer[] obstacleList;

    private ScoreManager theScoreManager;

    public FinalMenu theFinalScreen;

    private float moveSpeedStore;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCountStore;
    //private GameObject theOwl;

    // Start is called before the first frame update
    void Start()
    {
        obstacleStartPoint = obstacleGenerator.position;
        obstacleStartPointAbove = obstacleGeneratorAbove.position;
        grassStartPoint = grassGenerator.position;
        goodBugStartPoint = goodBugGenerator.position;
        badBugStartPoint = badBugGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();

        moveSpeedStore = thePlayer.moveSpeed_Main;
        speedMilestoneCountStore = thePlayer.speedIncreaseMilestone;
        speedIncreaseMilestoneStore = thePlayer.speedIncreaseMilestone;
        //theOwl = thePlayer.gameObject.transform.GetChild(0).gameObject;
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
        //thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", false);
        thePlayer.moveSpeed_Main = moveSpeedStore;
        thePlayer.speedIncreaseMilestone = speedMilestoneCountStore;
        thePlayer.speedIncreaseMilestone = speedIncreaseMilestoneStore;
        //thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().runtimeAnimatorController = theOwlAnimator.runtimeAnimatorController as RuntimeAnimatorController;
        obstacleGenerator.position = obstacleStartPoint;
        obstacleGeneratorAbove.position = obstacleStartPointAbove;
        grassGenerator.position = grassStartPoint;
        goodBugGenerator.position = goodBugStartPoint;
        badBugGenerator.position = badBugStartPoint;
        thePlayer.gameObject.SetActive(true);
        //Animator theOwlAnim = thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        //theOwlAnim.keepAnimatorControllerStateOnDisable=true;
        //thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().runtimeAnimatorController = theOwlAnim.runtimeAnimatorController as RuntimeAnimatorController;
        //theOwlAnim.enabled = false;
        //theOwlAnim.enabled = true;
        //theOwlAnim.Play("Owl_fly_init");
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

    }
    public IEnumerator RestartGameCoroutine()
    {
        thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", true);
        AudioManager.instance.PlaySFX(7);
        yield return new WaitForSeconds(1.2f);
        thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", false);

        thePlayer.gameObject.SetActive(false);

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
        thePlayer.moveSpeed_Main = moveSpeedStore;
        thePlayer.speedIncreaseMilestone = speedMilestoneCountStore;
        thePlayer.speedIncreaseMilestone = speedIncreaseMilestoneStore;
        obstacleGenerator.position = obstacleStartPoint;
        obstacleGeneratorAbove.position = obstacleStartPointAbove;
        grassGenerator.position = grassStartPoint;
        goodBugGenerator.position = goodBugStartPoint;
        badBugGenerator.position = badBugStartPoint;
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }
}
