using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinder : MonoBehaviour {

    private Dictionary<string, KeyCode> actionsKeys = new Dictionary<string, KeyCode>(); //lookup table of actions and keycodes

    //list of actions that a tank can perform (used to make intelisense available in other scripts i.e. : KeyBinder.move == StateManager.currentAction)
    public static string move = "Move";
    public static string turn = "Turn";

    private GameObject reassignButton;

    public Text moveTx, turnTx; //references to the Text in the UI canvas that displays the game controls
    public Text moveActionTx, turnActionTx; //references to the Action Labels in the UI (what action the button is reassigning)
    public GameObject moveButton, turnButton;

    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);

	// Use this for initialization
	void Start () {
        //maps keyCode to the action that is to be performed 
        actionsKeys.Add(move, KeyCode.M);
        actionsKeys.Add(turn, KeyCode.T);

        //changes the text in the game controls display
        moveTx.text = actionsKeys[move].ToString();
        turnTx.text = actionsKeys[turn].ToString();
        moveActionTx.text = move;
        turnActionTx.text = turn;
        moveButton.name = move;
        turnButton.name = turn;
        moveButton.GetComponent<Image>().color = normal;
        turnButton.GetComponent<Image>().color = normal;
    }
	
	// Update is called once per frame
	void Update () {
        // when the apropriate key is pressed, the keyBinder changes the state in the stateManager
        if (Input.GetKeyDown(actionsKeys[move]))
        {
            Debug.Log("Ready to select tank to move");
            StateManager.currentAction = move;
        }

        if (Input.GetKeyDown(actionsKeys[turn]))
        {
            StateManager.currentAction = turn;
        }

        if(StateManager.currentAction == move)
        {
            moveActionTx.GetComponent<Text>().color = Color.red;
        }
        else
        {
            moveActionTx.GetComponent<Text>().color = Color.black;
        }

        if (StateManager.currentAction == turn)
        {
            turnActionTx.GetComponent<Text>().color = Color.red;
        }
        else
        {
            turnActionTx.GetComponent<Text>().color = Color.black;
        }

    }

    private void OnGUI()
    {
        if(reassignButton != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                actionsKeys[reassignButton.name] = e.keyCode;
                reassignButton.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                reassignButton.GetComponent<Image>().color = normal;
                reassignButton = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (reassignButton != null)
            reassignButton.GetComponent<Image>().color = normal;

        reassignButton = clicked;
        reassignButton.GetComponent<Image>().color = selected;
    }
}
