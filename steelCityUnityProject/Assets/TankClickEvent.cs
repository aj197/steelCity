using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankClickEvent : MonoBehaviour {

    public delegate void clickTask();
    public static event clickTask TankClicked;

    private void OnMouseDown()
    {
        Debug.Log("Hi");

        if (TankClicked != null)
        {
            TankClicked();
        }
    }

}
