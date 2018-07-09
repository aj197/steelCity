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

        if (StateManager.currentAction == KeyBinder.move)
            MoveActionSequence();

        if (StateManager.currentAction == KeyBinder.turn)
            TurnActionSequence();

    }

    void MoveTank(Transform tile)
    {
        this.transform.position = tile.position;
        StateManager.isMovingTank = false;
    }

    void TurnActionSequence()
    {

    }

    void MoveActionSequence()
    {
        if (Input.GetMouseButtonDown(0) && StateManager.isMovingTank == false)
        {
            Debug.Log("click");
            if (Physics.Raycast(ray, out hit) && hit.transform == this.transform) //checks for hitting tank
            {
                StateManager.isMovingTank = true;
                StateManager.currentTank = this;

                //activcate move sequence-gen ghost, move maxdistance
                GameObject ghostTank = Instantiate(tank.ghost, transform.position + Vector3.forward * GameManager.tileDistance, transform.rotation) as GameObject;
                ghostTank.GetComponent<GhostMove>().SetMoveParameters(tank.maxDistance, transform.position); //creates ghost tank object in game at position of the tank its clicked on
            }
        }

        if (Input.GetMouseButtonDown(0) && StateManager.isMovingTank == true)
        {
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Tile")
            {
                if (hit.transform.gameObject.GetComponent<Tile>().isHighlighted == true && StateManager.currentTank == this)
                {
                    MoveTank(hit.transform);
                }
            }
        }
    }
}
