using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    //highlights game tiles when a tank is clicked that that tank can move to

    private void OnEnable() //subscribes event
    {
        TankObjectScript.TankClicked += Highlight;
    }

    private void OnDisable() //unsubscribes event
    {
        TankObjectScript.TankClicked -= Highlight;
    }

    void Highlight() //method doing the work
    {
        Color col = new Color(100, 100, 100);
        //gameObject.renderer.
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
