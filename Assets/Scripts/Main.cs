using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//high how r u? high

public class Main : MonoBehaviour
{
    // Initialization
    public GameObject floor;
    public GameObject[] myPrefab; //holds prefabs for all ant types. Use indexing to indicated different ant types
    public GameObject[] ant; //individual ants spawned for each type
    public float targetTime; //time to create or destroy ants
    private float targetTimeCopy; //for reseting time

    public string dirtDigStatus;

    // Start is called before the first frame update
    void Start()
    {
       targetTimeCopy = targetTime;
       //CreateFloor(-20f, -2f, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            antBirthKillEnded();
            targetTime = targetTimeCopy;
        }
    }

    /*
    public void CreateFloor(float xStart, float yStart, int xNum, int yNum)
    {

        var floorHeight = floor.GetComponent<SpriteRenderer>().bounds.size.x;
        var floorWidth = floor.GetComponent<SpriteRenderer>().bounds.size.x;
        var xHang = xStart;
        var yHang = yStart;

        for (int i = 0; i < xNum; i++)
        {
            for (int j = 0; j < yNum; j++)
            {
                Instantiate(floor, new Vector3(xHang, yHang, 0), Quaternion.identity);
                xHang += floorWidth;
            }

            xHang = xStart;
            yHang -= floorHeight;

        }
    }
    */


    // Generate n number of ants at random locations on the surface
    public void BirthAnts(int n, int antType, float xmin, float xmax)
    { 

        for (int i = 0; i < n; i++)
        {

            ant[i] = Instantiate(myPrefab[antType], new Vector3(Random.Range(xmin, xmax), 0, 0), Quaternion.identity);

            
        }
    }

    // Kill n random ants
    public void KillAnts(int n)
    {
        int idx;

        for (int i = 0; i < n; i++)
        {
           idx = Random.Range(0, ant.Length); // find random ant to kill
            while (ant[idx] == null)
            {
                idx = Random.Range(0, ant.Length); // find random ant to kill
            }
           Destroy(ant[idx], 3f); 
           

        }
    }

    void antBirthKillEnded()
    {
        //do your stuff here.
        BirthAnts(20, 0, -20f, 20f); // birth 5 ants of type 0 within x vals of (-20f,20f)
        KillAnts(15); // kill 2 random ants
    }
}
