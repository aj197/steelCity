using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tanks : MonoBehaviour {

	void Start () {
		
	}

    public TankObject tank;
    private int tile;
    
  
    void Awake()
    {
        tile = LayerMask.GetMask("Tile");
    }

	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            if (Physics.Raycast(ray, out hit) && hit.transform == this.transform) //checks for hitting tank
            {
                //activcate move sequence-gen ghost, move maxdistance
                GameObject ghostTank = Instantiate(tank.ghost, transform.position + Vector3.forward * GhostMove.tileDistance, transform.rotation) as GameObject;

                ghostTank.GetComponent<GhostMove>().move(tank.maxDistance, transform.position); //creates ghost tank object in game at position of the tank its clicked on
            }                            
        }
       //should raycast check for tiles:
       // if(Physics.Raycast(ray, out hit, Mathf.Infinity, tile))
       
    }



    //put all methods in this class

















}
