using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tanks : MonoBehaviour {

    public TankObject tank;
    private int tileLayer;

    void Start () {
		
	}
  
    void Awake()
    {
        tileLayer = LayerMask.GetMask("Tile");
    }

	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && StateManager.isMovingTank == false)
        {
            Debug.Log("click");
            if (Physics.Raycast(ray, out hit) && hit.transform == this.transform) //checks for hitting tank
            {
                StateManager.isMovingTank = true;

                //activcate move sequence-gen ghost, move maxdistance
                GameObject ghostTank = Instantiate(tank.ghost, transform.position + Vector3.forward * GameManager.tileDistance, transform.rotation) as GameObject;

                ghostTank.GetComponent<GhostMove>().SetMoveParameters(tank.maxDistance, transform.position); //creates ghost tank object in game at position of the tank its clicked on
            }                            
        }

        if (Input.GetMouseButtonUp(1))
        {
            StateManager.isMovingTank = false;
        }


       //should raycast check for tiles:
       // if(Physics.Raycast(ray, out hit, Mathf.Infinity, tile))

    }



    //put all tank methods in this class

















}
