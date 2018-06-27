using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankObjectScript : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
