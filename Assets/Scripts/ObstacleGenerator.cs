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

    public bool isAbove;
    public GameObject[] theObstacles;
    private int obstacleSelector;
    private float[] obstacleHights;
    private float[] obstacleWidths;


    // Start is called before the first frame update
    void Start()
    {

        //obstacleWidth = theObstacle.GetComponent <BoxCollider2D>().size.x;

        obstacleWidths = new float[theObstacles.Length];
        obstacleHights = new float[theObstacles.Length];

        for (int i=0; i<theObstacles.Length; i++)
        {
            obstacleHights[i] = theObstacles[i].GetComponent<BoxCollider2D>().size.y;
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
    
            obstacleSelector = Random.Range(0, theObstacles.Length);

            transform.position = new Vector3(transform.position.x + 5*obstacleWidths[obstacleSelector] + distanceBetween, 
                transform.position.y , transform.position.z);

            Vector3 shiftY;
            if (isAbove)
                shiftY = new Vector3(0f, (float)-2.5*obstacleHights[obstacleSelector], 0f);
            else
                shiftY = new Vector3(0f, (float)2.5 * obstacleHights[obstacleSelector], 0f);
            //Debug.Log(obstacleYpos[obstacleSelector]);
            Instantiate(theObstacles[obstacleSelector], transform.position+ shiftY, transform.rotation);
            //Instantiate(theObstacles[obstacleSelector], transform.position, transform.rotation);
        }
    }
 
}
