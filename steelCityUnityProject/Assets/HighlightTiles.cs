using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTiles : MonoBehaviour {

    //highlights game tiles when a tank is clicked that that tank can move to

    public Material highlightMat;
    public Material originalMat;
    public Renderer tile;
    
    
    public void Highlight() //method doing the work
    {
        //TankObject tank;
            //Debug.Log(tank);
            tile.material = highlightMat;
        
       
    }

    void Update() //checks if rmb is pressed to deselect tank
    {
        if (Input.GetMouseButtonUp(1))
        {
            tile.material = originalMat;
        }
    }
}
