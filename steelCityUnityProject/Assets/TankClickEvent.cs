using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankClickEvent : MonoBehaviour {

    //activates the event 'TankClicked' when a tank gameobject is clicked. Note, OnMouseDown needs a collider to work

    public delegate void clickTask();
    public static event clickTask TankClicked;
    public GameObject tank;

    private void OnMouseDown()
    {
        Debug.Log("Hi");

        if (TankClicked != null)
        {
             
            TankClicked();
        }
    }

}
