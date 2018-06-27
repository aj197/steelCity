using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    //speeds for panning/zooming
    private static readonly float PanSpeed = 30f;
    private static readonly float ZoomSpeedTouch = 5f;
    private static readonly float ZoomSpeedMouse = 10f;

    //determines the bounds for the pan/zoom (pls dont touch, took me a while to get right!)
    private static readonly float[] BoundsX = new float[] { -40f, 40f };
    private static readonly float[] BoundsZ = new float[] { -70f, 30f };
    private static readonly float[] ZoomBounds = new float[] { 10f, 85f };

    private Camera cam;

    private Vector3 lastPanPosition;

    //touch mode variables
    private int panFingerID;
    private bool wasZoomingLastFrame;
    private Vector2[] lastZoomPositions;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {

    }

    void Update()
    {
        //decides whether to use touch or mouse controls
        if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer) //webGL supports touch controls even on desktop, why we check for it
        {
            UseTouch();
        }
        else
        {
            UseMouse();
        }

    }


    void UseTouch()
    {

    }

    void UseMouse()
    {
        if (Input.GetMouseButtonDown(0)) //checks if mouse was clicked & gets position
        {
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0)) //if not clicked, run PanCamera method
        {
            PanCamera(Input.mousePosition);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll, ZoomSpeedMouse);
    }


    void PanCamera(Vector3 newPanPosition)
    {   //determines how far to move camera
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * PanSpeed, 0, offset.y * PanSpeed);

        //moves camera
        transform.Translate(move, Space.World);

        //checks bounds
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
        pos.z = Mathf.Clamp(transform.position.z, BoundsZ[0], BoundsZ[1]);
        transform.position = pos;

        //saves position
        lastPanPosition = newPanPosition;
    }

    void ZoomCamera(float offset, float speed)
    {
        if (offset == 0)
        {
            return;
        }

        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);
    }
}
