using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDisplayScript : MonoBehaviour {

    //displays the information created in the 'TankObject' scriptable object script
    public TankObject tank;


    void Start() //put stuff that needs to be initialized on start for each tank in here eventually
    {
        
    }

    private void OnEnable() //subscribes event
    {
        TankClickEvent.TankClicked += tank.printHealth;
    }

    private void OnDisable() //unsubscribes event
    {
        TankClickEvent.TankClicked -= tank.printHealth;
    }





}
