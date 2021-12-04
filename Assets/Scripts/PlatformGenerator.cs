using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject theObstacle;
    public Transform generationPoint;

    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public bool isRandomised;
    private float obstacleWidth;



    // Start is called before the first frame update
    void Start()
    {
        obstacleWidth = theObstacle.GetComponent <BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            if (isRandomised)
                distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
           
            transform.position = new Vector3(transform.position.x + 5*obstacleWidth + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(theObstacle, transform.position, transform.rotation);
        }
    }
}
