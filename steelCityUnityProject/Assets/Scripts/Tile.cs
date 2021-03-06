﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    //highlights game tiles when a tank is clicked that that tank can move to

    public Material highlightMat;
    public Material originalMat;
    public Material mouseHoverMat;
    public Renderer tileRenderer;
    public bool isHighlighted = false;
    public static List<GameObject> mapTiles;

    RaycastHit hit;
    Ray ray;

    public void Highlight() //method doing the work
    {
        tileRenderer.material = highlightMat;
        isHighlighted = true;
    }

    public void UnHighlight()
    {
        tileRenderer.material = originalMat;
        isHighlighted = false;
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
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (isHighlighted)
        {
            if(Physics.Raycast(ray, out hit) && hit.transform == this.transform)
            {
                tileRenderer.material = mouseHoverMat;
            }
            else
            {
                tileRenderer.material = highlightMat;
            }
        }
        else
        {
            tileRenderer.material = originalMat;
        }

    }
}
