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

    public static float tileDistance;

    public void move(int max, Vector3 tankPosition)
    {
        distanceLimit = max;
        tankPos = tankPosition;
    }
  
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tile")
        {
            tileList.Add(other.gameObject);                      
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Immobile"))
        {
            isImmobile = true;   
        }
    }

    private void Start()
    {
        tileDistance = tile.GetComponent<BoxCollider>().size.x;
        Debug.Log(tileDistance);
    }

    void highlightTileList()
    {
        foreach (GameObject tile in tileList)
        {
            tile.GetComponent<HighlightTiles>().Highlight();
        }
    }
    
    void Update()
    {  //for some reason 7 is a good constant of proportionality for the distance limit
        if(!isImmobile && (distance < (tileDistance*distanceLimit)))
        {
            distance = Vector3.Distance(tankPos, transform.position);
            transform.position += transform.forward * 100f * Time.deltaTime; //moves ghost tank  
        }
        else
        {
            highlightTileList();
            Destroy(this.gameObject);
        }
    }
    
    
}
