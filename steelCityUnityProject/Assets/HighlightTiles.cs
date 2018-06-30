using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTiles : MonoBehaviour {

    //highlights game tiles when a tank is clicked that that tank can move to

    private void OnEnable() //subscribes event
    {
        TankClickEvent.TankClicked += Highlight;
    }

    private void OnDisable() //unsubscribes event
    {
        TankClickEvent.TankClicked -= Highlight;
    }

    public Material highlightMat;
    public Material originalMat;
    public Renderer tile;
    public GameObject gridSpace;

    TankClickEvent tankToMove;
    
    void Highlight() //method doing the work
    {
        if (true)
        {
            tile.material = highlightMat;
            //tankToMove.
        }
       
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            tile.material = originalMat;
        }
    }
}
