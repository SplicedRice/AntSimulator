using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antDo : MonoBehaviour
{
    private Vector3 newPosition; //clicked position
    public float speed = 1.5f; //speed of ants
    public bool isMovingTowardsPoint = false; //track if ants are moving towards a designated point
    public float targetTime; //time to create or destroy ants
    private float targetTimeCopy; //for reseting time

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        targetTimeCopy = targetTime;

    }


    // Update is called once per frame
    void Update()
    {

        targetTime -= Time.deltaTime;


        // Move ants to target position
        if (Input.GetMouseButtonDown(0))
        {
            newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = transform.position.z;
            isMovingTowardsPoint = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

        if (transform.position.x == newPosition.x)
        {
            isMovingTowardsPoint = false;
            targetTime = targetTimeCopy;
        }

        if (isMovingTowardsPoint == false && targetTime <= 0.0f)
        {

            idleMovement(-8, 8);
            
           
        }


    }

    void idleMovement(float xmin,float xmax)
    {
        newPosition = new Vector3(Random.Range(xmin, xmax),0,0);
    }
 }
