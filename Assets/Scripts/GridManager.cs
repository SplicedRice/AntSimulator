using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 5;
    public int cols = 8;
    public float tileSize = 1;
    private GameObject dirtTile;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {

        GameObject dirtTile = (GameObject)Instantiate(Resources.Load("dirtBlock"));

        for (int c = 0; c < cols; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                SpawnTile(c * tileSize, r * -tileSize, dirtTile);
            }
        }

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        //var centerVect = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
        var centerVect = new Vector2(-gridW / 2 + tileSize / 2, -gridH / 4 - tileSize / 2);
        transform.position = centerVect;

    }

    // Update is called once per frame
    private void SpawnTile(float x, float y, GameObject g)
    {
        //GameObject g = new GameObject("X: " + x + "  Y: " + y);
        //g.transform.position = new Vector3(x - (hSize - 0.5f), y - (vSize - 0.5f));
        Instantiate(g, transform);
        g.transform.position = new Vector2(x, y);
        //var s = g.AddComponent<SpriteRenderer>();
        g.GetComponent<SpriteRenderer>().sortingLayerName = "test2";
        g.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
