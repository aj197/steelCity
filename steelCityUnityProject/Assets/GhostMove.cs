using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

    private float distance = 0;
    private int distanceLimit;
    private Vector3 tankPos = new Vector3();
    private bool isImmobile = false;
    private ArrayList tileList = new ArrayList();
    public GameObject tile;


    public void SetMoveParameters(int max, Vector3 tankPosition)
    {
        distanceLimit = max;
        tankPos = tankPosition;
    }
  
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tile")
        {
            other.GetComponent<Tile>().Highlight();
            //tileList.Add(other.gameObject);             //for highlighting all at once         
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Immobile"))
        {
            isImmobile = true;   
        }
    }

    private void Start()
    {

    }

    void HighlightTileList()
    {
        foreach (GameObject tile in tileList)
        {
            tile.GetComponent<Tile>().Highlight();
        }
    }
    
    void Update()
    {  //for some reason 7 is a good constant of proportionality for the distance limit
        if(!isImmobile && (distance < (GameManager.tileDistance * distanceLimit)))
        {
            distance = Vector3.Distance(tankPos, transform.position);
            transform.position += transform.forward * 100f * Time.deltaTime; //moves ghost tank  
        }
        else
        {
            //HighlightTileList();      //for highlighting all at once
            Destroy(this.gameObject);
        }
    }
    
    
}
