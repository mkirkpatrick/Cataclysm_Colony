using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	Vector3 worldOrigin;

	public LayerMask layerMask;

	public float distanceFromOrigin;
	public float mouseAngle;

	void Start(){
		worldOrigin = new Vector3 (0, 0, 0);
	}

	void Update() {

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 300f, layerMask)) {
			distanceFromOrigin = Vector3.Distance (worldOrigin, hit.point);
			mouseAngle = FindDegree(hit.point.x, hit.point.z);
		}
	}

	public float FindDegree(float x, float y){
		float value = (float)((Mathf.Atan2(x, y) / Mathf.PI) * 180f);
		if(value < 0) value += 360f;

		return value;
	}

    //Mouse Cursor Functions

    public void SetCursorImage(int cursorNum)
    {
        //Cursor.SetCursor(cursorTextures[cursorNum], Vector2.zero, CursorMode.Auto);
    }
}