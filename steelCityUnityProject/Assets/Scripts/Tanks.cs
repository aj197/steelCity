using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tanks : MonoBehaviour
{

    public TankObject tank;
    private int tileLayer;
    RaycastHit hit;
    Ray ray;

    void Start()
    {

    }

    void Awake()
    {
        tileLayer = LayerMask.GetMask("Tile");
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && hit.transform == this.transform) //checks for hitting tank
            {
                StateManager.SetCurrentTank(transform.gameObject);
                Debug.Log(this);
                StateManager.SetActionsToFalse();
            }
        }

        if (StateManager.currentTank == transform.gameObject)
        {
            if (StateManager.currentAction == KeyBinder.move)
                MoveActionSequence();

            if (StateManager.currentAction == KeyBinder.turn)
                TurnActionSequence();
        }

    }



    void TurnActionSequence()
    {
        if (StateManager.isTurningTank == false)
        {
            StateManager.SetTurningTank(true);

            GameObject ghostTankForward = Instantiate(tank.ghost, transform.position + Vector3.forward * GameManager.tileDistance, Quaternion.LookRotation(Vector3.forward, Vector3.up)) as GameObject;
            GameObject ghostTankRight = Instantiate(tank.ghost, transform.position + Vector3.right * GameManager.tileDistance, Quaternion.LookRotation(Vector3.right, Vector3.up)) as GameObject;
            GameObject ghostTankLeft = Instantiate(tank.ghost, transform.position + Vector3.left * GameManager.tileDistance, Quaternion.LookRotation(Vector3.left, Vector3.up)) as GameObject;
            GameObject ghostTankBack = Instantiate(tank.ghost, transform.position + Vector3.back * GameManager.tileDistance, Quaternion.LookRotation(Vector3.back, Vector3.up)) as GameObject;

            ghostTankForward.GetComponent<GhostMove>().SetMoveParameters(2, transform.position);
            ghostTankRight.GetComponent<GhostMove>().SetMoveParameters(2, transform.position);
            ghostTankLeft.GetComponent<GhostMove>().SetMoveParameters(2, transform.position);
            ghostTankBack.GetComponent<GhostMove>().SetMoveParameters(2, transform.position);

        }

        if (Input.GetMouseButtonUp(0) && StateManager.isTurningTank == true)
        {
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Tile")
            {
                if (hit.transform.gameObject.GetComponent<Tile>().isHighlighted == true)
                {
                    TurnTank(hit.transform);
                }
            }
        }

    }

    void MoveActionSequence()
    {
       
        if (StateManager.isMovingTank == false)
        {
            StateManager.SetMovingTank(true);
            //activcate move sequence-gen ghost, move maxdistance
            GameObject ghostTank = Instantiate(tank.ghost, transform.position + transform.forward * GameManager.tileDistance, transform.rotation) as GameObject;
            ghostTank.GetComponent<GhostMove>().SetMoveParameters(tank.maxDistance, transform.position); //creates ghost tank object in game at position of the tank its clicked on
        }

        if (Input.GetMouseButtonUp(0) && StateManager.isMovingTank == true)
        {
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Tile")
            {
                if (hit.transform.gameObject.GetComponent<Tile>().isHighlighted == true)
                {
                    MoveTank(hit.transform);
                }
            }
        }

    }




    void MoveTank(Transform tile)
    {
        this.transform.position = tile.position;
        StateManager.SetActionsToFalse();
        StateManager.SetCurrentTank(null);
    }

    void TurnTank(Transform tile)
    {
        this.transform.rotation = Quaternion.LookRotation(tile.position - this.transform.position, Vector3.up);
        StateManager.UnfocusTank();
    }
}
