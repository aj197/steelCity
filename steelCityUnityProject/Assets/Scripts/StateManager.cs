using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public static bool isChangingAction = false;
    public static bool isMovingTank = false; //true if you have selected a tank and have highlighted potential tiles to move to
    public static bool isTurningTank = false;
    public static GameObject currentTank;  //the tank that is currently selected
    private GameObject oldTank;
    public static string currentAction; //the action that you want the selected tank to perform
    private string oldAction;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            UnfocusTank();
        }

    }
    
    public static void SetMovingTank(bool b)
    {
        if (b != isMovingTank)
            ChangingState();
        ClearActionVariables();
        isMovingTank = b;
    }
    public static void SetTurningTank(bool b)
    {
        if (b != isTurningTank)
            ChangingState();
        ClearActionVariables();
        isTurningTank = b;
    }

    public static void SetCurrentAction(string s)
    {
        if (s != currentAction)
            ChangingState();
        currentAction = s;
    }

    public static void SetCurrentTank(GameObject t)
    {
        if (t != currentTank)
            ChangingState();
        currentTank = t;
    }

    private static void ChangingState()
    {
        foreach(GameObject tile in Tile.mapTiles)
        {
            tile.GetComponent<Tile>().UnHighlight();
        }
        GhostMove.isRunning = false;
    }

    private static void ClearActionVariables()
    {
        isMovingTank = false;
        isTurningTank = false;
    }

    public static void SetActionsToFalse()
    {
        SetMovingTank(false);
        SetTurningTank(false);
    }

    public static void UnfocusTank()
    {
        SetActionsToFalse();
        SetCurrentTank(null);
        SetCurrentAction("");
    }

}
