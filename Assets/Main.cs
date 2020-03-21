using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//high how r u?

public class Main : MonoBehaviour
{

    public GameObject myPrefab;
    public float targetTime;
    private float targetTimeCopy;


    // Start is called before the first frame update
    void Start()
     {
       targetTimeCopy = targetTime;
     }

// Update is called once per frame
void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
            targetTime = targetTimeCopy;
        }
    }


    // Generate a random number of ants on the surface
    public void BirthAnts(int n, float xmin, float xmax)
    { 

        for (int i = 0; i < n; i++)
        {

            Instantiate(myPrefab, new Vector3(Random.Range(xmin, xmax), 0, 0), Quaternion.identity);

            
        }
    }

    void timerEnded()
    {
        //do your stuff here.
        BirthAnts(10, -20f, 20f);
    }
}
