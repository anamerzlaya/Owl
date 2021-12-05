using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBugGenerator : MonoBehaviour
{
    public GameObject theBug;
    public Transform generationPoint;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public float minHight, maxHight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            float distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            float rotationNew = Random.Range(0, 360);
            float YpositionNew = Random.Range(minHight, maxHight);

            transform.position = new Vector3(transform.position.x  + distanceBetween, YpositionNew, transform.position.z);
            Vector3 rotationVector = new Vector3(transform.rotation.x , transform.rotation.y, transform.rotation.z +rotationNew);
            transform.rotation = Quaternion.Euler(rotationVector);

            Instantiate(theBug, transform.position, transform.rotation);
        }
    }
}
