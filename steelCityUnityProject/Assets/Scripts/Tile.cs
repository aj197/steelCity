using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    //highlights game tiles when a tank is clicked that that tank can move to

    public Material highlightMat;
    public Material originalMat;
    public Renderer tileRenderer;
    public bool isHighlighted = false;
    public static List<GameObject> mapTiles;

    public void Highlight() //method doing the work
    {
        tileRenderer.material = highlightMat;
        isHighlighted = true;
    }

    void OnEnable()
    {
        if(mapTiles == null)
        {
            mapTiles = new List<GameObject>();
            GameManager.tileDistance = GetComponent<Collider>().bounds.size.x;
            Debug.Log(GameManager.tileDistance);
        }
        mapTiles.Add(this.gameObject);
    }

    void OnDisable()
    {
        mapTiles.Remove(this.gameObject);
    }

    void Update() //checks if rmb is pressed to deselect tank
    {
        if (StateManager.isMovingTank == false)
        {
            tileRenderer.material = originalMat;
            isHighlighted = false;
        }
    }
}
