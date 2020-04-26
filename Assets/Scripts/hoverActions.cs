using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverActions : MonoBehaviour
{

    private Sprite spriteSaver;
    Sprite selectedBlock;
    Sprite hoverBlock;
    GameObject GameFlowRef;
    MainScript gameFlowScript;

    // Start is called before the first frame update
    void Start()
    {
        selectedBlock = Resources.Load<Sprite>("Sprites/selectedBlock");
        hoverBlock = Resources.Load<Sprite>("Sprites/hoverBlock");

        GameFlowRef = GameObject.FindGameObjectsWithTag("GameFlow")[0];
        gameFlowScript = GameFlowRef.GetComponent<MainScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = selectedBlock;
        Debug.Log("dwoner");
        if (gameFlowScript.dirtDigStatus != "SELECT")  gameFlowScript.dirtDigStatus = "SELECT";
    }

    private void OnMouseUp()
    {
        if (gameFlowScript.dirtDigStatus != "STOP_SELECT") gameFlowScript.dirtDigStatus = "STOP_SELECT";
    }

    void OnMouseEnter()
    {

        spriteSaver = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        Debug.Log("whater");

        if (gameFlowScript.dirtDigStatus == "SELECT")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = selectedBlock;
        }

        else if (gameFlowScript.dirtDigStatus != "SELECT")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hoverBlock;
        } 

    }

    void OnMouseExit()
    {
        if (gameFlowScript.dirtDigStatus != "SELECT")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteSaver;
        }
    }
}
