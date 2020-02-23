using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//high how r u?

public class Main : MonoBehaviour
{

    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {

        float xHang = -8f;

        for (int i = 0; i < 100; i++)
        {
            Instantiate(myPrefab, new Vector3(xHang, 0, 0), Quaternion.identity);

            xHang += 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
