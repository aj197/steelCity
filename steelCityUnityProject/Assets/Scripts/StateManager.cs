using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {


    public static bool isMovingTank = false; //true if you have selected a tank and have highlighted potential tiles to move to
    public static Tanks currentTank;  //the tank that is currently selected
    public static string currentAction; //the action that you want the selected tank to perform

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            isMovingTank = false;
        }


    }
}
