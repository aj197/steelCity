using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

    private float distance = 0;
    private int distanceLimit;
    private Vector3 tankPos = new Vector3();
    private bool isImmobile = false;

    public void move(int max, Vector3 tankPosition)
    {
        distanceLimit = max;
        tankPos = tankPosition;
    }

   
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("yo");
        if(other.gameObject.tag == "Immobile")
        {
            Debug.Log("immobile!");
            isImmobile = true;
        }
    } 



    void Start() {
       
    }
    
    void Update()
    {  //for some reason 7 is a good constant of proportionality for the distance limit
        if(!isImmobile && (distance < (7*distanceLimit))) //dont forget to add in immpassable colliders to this statement!
        {
            distance = Vector3.Distance(tankPos, transform.position);
            transform.position += transform.forward * 10f * Time.deltaTime; //moves ghost tank
            //should also call highlight here

            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    
}
