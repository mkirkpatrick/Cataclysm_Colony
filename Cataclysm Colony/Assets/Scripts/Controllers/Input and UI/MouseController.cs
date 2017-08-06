using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    public enum MouseZone { OpenPlot, BaseBuilding, Wall}

    public Vector2 worldOrigin;
    public Vector2 mouseWorldPoint;
    public float mouseDistance;
    public float mouseAngle;

    //Mouse Cursor Data
    public Texture2D[] cursorTextures;

    // Use this for initialization
    void Start () {
        worldOrigin = new Vector2(0, 0);
        //SetCursorImage(0);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMousePositionData();

        Debug.Log(GetMouseSector(mouseAngle));

    }

    void UpdateMousePositionData() {
        mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseDistance = Vector2.Distance(worldOrigin, mouseWorldPoint);

        mouseAngle = Mathf.Atan2(mouseWorldPoint.y - worldOrigin.y, mouseWorldPoint.x - worldOrigin.x) * -180 / Mathf.PI;
        mouseAngle += 180;
    }

    public int GetMouseSector(float angle) {
        int result;
        /*
        if (angle >= 22.5 && angle < 67.5f)
            result = 7;
        else if (angle >= 67.5f && angle < 112.5f)
            result = 0;
        else if (angle >= 112.5f && angle < 157.5f)
            result = 1;
        else if (angle >= 157.5f && angle < 202.5f)
            result = 2;
        else if (angle >= 202.5f && angle < 247.5f)
            result = 3;
        else if (angle >= 247.5f && angle < 292.5f)
            result = 4;
        else if (angle >= 292.5f && angle < 337.5f)
            result = 5;
        else
            result = 6;
*/

        int divs = GetRingDivisions(mouseDistance);



        float newAngle;
        if (mouseDistance > 4 && mouseDistance <= 10.187f)
            newAngle = angle - 90f;
        else
            newAngle = ( angle-67.5f );
        if (newAngle < 0)
            newAngle += 360;

        float angleRatio = newAngle / 360f;

        result = Mathf.FloorToInt(angleRatio * divs );

        return result;
    }

    public int GetRingDivisions(float dist) {
        int result = 0;

        if (dist <= 1.5f)
            result = 0;
        else if (dist <= 6f)
            result = 8;
        else if (dist <= 10.187f)
            result = 16;
        else if (dist <= 14f)
            result = 24;
        else
            result = 8;

        return result;
    }

    //Mouse Cursor Functions

    public void SetCursorImage(int cursorNum)
    {
        Cursor.SetCursor(cursorTextures[cursorNum], Vector2.zero, CursorMode.Auto);
    }
}