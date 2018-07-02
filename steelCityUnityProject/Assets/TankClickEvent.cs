using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //OLD CLASS
public class TankClickEvent : MonoBehaviour {

    //activates the event 'TankClicked' when a tank gameobject is clicked. 
    //Note: OnMouseDown needs a collider to work

    public delegate void clickTask();
    public static event clickTask TankClicked;

    //some raycast stuff i was fiddling round with

    void update()
    {

    if (Input.GetMouseButtonDown(0))
        {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        
        
        if(Physics.Raycast(ray, out hit))
            {
            Debug.Log("Hit");
            TankClicked();
            }
        }
    }



    /*   private void OnMouseDown(){

           Debug.Log("Click");

           if (TankClicked != null)
           {    
               TankClicked();
           }
       } */

}
