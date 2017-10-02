﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const int LevelArea = 100;

    private const int ScrollArea = 25;
    private const int ScrollSpeed = 25;
    private const int DragSpeed = 100;

    private const int ZoomSpeed = 60;
    private const int ZoomMin = 80;
    private const int ZoomMax = 160;

    private const int PanSpeed = 10;
    private const int PanAngleMin = 30;
    private const int PanAngleMax = 50;

    // Update is called once per frame
    void Update()
	{
		if (UIController.Instance.lockOtherInput == false) {
			MoveCamera ();
		}   
	}

	private void MoveCamera(){

		// Init camera translation for this frame.
		var translation = Vector3.zero;

		// Zoom in or out
		var zoomDelta = Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed * Time.deltaTime;
		if (zoomDelta != 0)
		{
			translation -= Vector3.up * ZoomSpeed * zoomDelta;
		}

		// Start panning camera if zooming in close to the ground or if just zooming out.
		var pan = transform.eulerAngles.x - zoomDelta * PanSpeed;
		pan = Mathf.Clamp(pan, PanAngleMin, PanAngleMax);
		if (zoomDelta < 0 || transform.position.y < (ZoomMax / 2))
		{
			transform.eulerAngles = new Vector3(pan, 0, 0);
		}

		// Move camera with arrow keys
		translation += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		// Move camera with mouse
		if (Input.GetMouseButton(2)) // MMB
		{
			// Hold button and drag camera around
			translation -= new Vector3(Input.GetAxis("Mouse X") * DragSpeed * Time.deltaTime, 0,
				Input.GetAxis("Mouse Y") * DragSpeed * Time.deltaTime);
		}
		else
		{
            /*
			// Move camera if mouse pointer reaches screen borders
			if (Input.mousePosition.x < ScrollArea)
			{
				translation += Vector3.right * -ScrollSpeed * Time.deltaTime;
			}

			if (Input.mousePosition.x >= Screen.width - ScrollArea)
			{
				translation += Vector3.right * ScrollSpeed * Time.deltaTime;
			}

			if (Input.mousePosition.y < ScrollArea)
			{
				translation += Vector3.forward * -ScrollSpeed * Time.deltaTime;
			}

			if (Input.mousePosition.y > Screen.height - ScrollArea)
			{
				translation += Vector3.forward * ScrollSpeed * Time.deltaTime;
			}*/
		}

		// Keep camera within level and zoom area
		var desiredPosition = transform.position + translation;
		if (desiredPosition.x < -LevelArea || LevelArea < desiredPosition.x)
		{
			translation.x = 0;
		}
		if (desiredPosition.y < ZoomMin || ZoomMax < desiredPosition.y)
		{
			translation.y = 0;
		}
		if (desiredPosition.z < -LevelArea || LevelArea < desiredPosition.z)
		{
			translation.z = 0;
		}

		// Finally move camera parallel to world axis
		transform.position += translation;
	}


}