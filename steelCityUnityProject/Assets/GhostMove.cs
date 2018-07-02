using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

    private float distance = 0;
    private int distanceLimit;
    private Vector3 tankPos = new Vector3();

    public void move(int max, Vector3 tankPosition)
    {
        distanceLimit = max;
        tankPos = tankPosition;
    }
    
    void Start() {

    }
    
    void Update()
    {
        if(true && distance < (distanceLimit)) //dont forget to add in immpassable colliders to this statement!
        {
            distance = Vector3.Distance(tankPos, transform.position);
            transform.position += transform.forward * .1f * Time.deltaTime; //moves ghost tank
            //should also call highlight here
        }     
    }
    
    
}
