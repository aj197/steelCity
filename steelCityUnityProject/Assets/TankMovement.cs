using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

    public GameObject tankToMove;
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if(Vector3.up != targetPosition.up)
        tankToMove.transform.position = Vector3.up * Time.time;
		
	}
}
