using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject theObstacle;
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public bool isRandomised;
    private float obstacleWidth;

    public GameObject[] theObstacles;
    private int obstacleSelector;
    private float[] obstacleWidths;

    // Start is called before the first frame update
    void Start()
    {
        obstacleWidth = theObstacle.GetComponent <BoxCollider2D>().size.x;

        obstacleWidths = new float[theObstacles.Length];

        for (int i=0; i<theObstacles.Length; i++)
        {
            obstacleWidths[i] = theObstacles[i].GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            if (isRandomised)
                distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
           
            transform.position = new Vector3(transform.position.x + 5*obstacleWidth + distanceBetween, transform.position.y, transform.position.z);

            obstacleSelector = Random.Range(0, theObstacles.Length);

            Instantiate(theObstacles[obstacleSelector], transform.position, transform.rotation);
        }
    }
}
