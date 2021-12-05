using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    private ScoreManager theScoreManager;
    public int scoreToTake;
    public GameObject thePlayer;


    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlayer = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(-scoreToTake);
            Debug.Log("obstacle collided with player");
            //Debug.Log(thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().GetBool("Hit"));
            thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", true);

            this.enabled = false;
            //gameObject.SetActive(false);
            StartCoroutine("RestartGameCoHit");

        }
    }
    public IEnumerator RestartGameCoHit()
    {

        yield return new WaitForSeconds(0.2f);
        thePlayer.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("Hit", false);

    }
}
