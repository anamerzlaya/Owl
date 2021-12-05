using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager theGameManager;

    public float moveSpeed_Main;
    private float moveSpeedStore;
    public float moveSpeed_x;
    public float moveSpeed_y;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public GameObject Owl;
    public float minHight, maxHight;


    private Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed_Main;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed_Main = moveSpeed_Main * speedMultiplier;
        }
        //theRB.velocity = new Vector2(moveSpeed_x * Input.GetAxis("Horizontal"), moveSpeed_y * Input.GetAxis("Vertical"));
        // if (Input.GetAxis("Horizontal")!=0) Debug.Log( theRB.velocity.x);
         float newXpos = transform.position.x;
         float newYpos = transform.position.y;
         if (Input.GetAxis("Horizontal") != 0)
             newXpos = transform.position.x + moveSpeed_x * Input.GetAxis("Horizontal");
         if (Input.GetAxis("Vertical") != 0)
             newYpos = transform.position.y + moveSpeed_y * Input.GetAxis("Vertical");
        //transform.position = new Vector3(newXpos, newYpos, transform.position.z);
        newXpos = newXpos + moveSpeed_Main;
        float clampedY = Mathf.Clamp(newYpos, minHight, maxHight);
        transform.position = new Vector3(newXpos, clampedY, transform.position.z);

        if (Input.GetAxis("Horizontal")>0)
            Owl.GetComponent<Animator>().SetBool("IsFlyForward", true);
        else if (Input.GetAxis("Horizontal")<0)
            Owl.GetComponent<Animator>().SetBool("IsFlyBackwards", true);
        else
        {
            Owl.GetComponent<Animator>().SetBool("IsFlyForward", false);
            Owl.GetComponent<Animator>().SetBool("IsFlyBackwards", false);
        }
        //Owl.GetComponent<Animator>().SetBool("Hit", false);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //RETHINK HOW TO ORGANISE BETTER
        if (other.gameObject.tag == "BadBug")
        {
            theGameManager.RestartGame();
            moveSpeed_Main = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }
}
