using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBugsController : MonoBehaviour
{

    public GameObject thePlayer;
    public float maxDistance;
    private GameObject childLight;
    private SpriteRenderer childSR;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
        childLight = transform.GetChild(0).gameObject;
        childSR = childLight.GetComponent<SpriteRenderer>();
        if (distance < maxDistance)
        {
            //childLight.GetComponent<SpriteRenderer>().color.a = distance / maxDistance;
            childSR.color = new Color(childSR.color.r, childSR.color.g, childSR.color.b, distance / maxDistance);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //END OF THE GAME
            Debug.Log("bug touched the owl!");
            FindObjectOfType<GameManager>().RestartGame();
            //gameObject.SetActive(false);
        }
    }
}
