using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtil {

    public static Vector3 GetPointOnCircle(float angle, float distance) {

		Vector3 point = new Vector3 (0, 0, 0);

		point.x = Mathf.Cos (Mathf.Deg2Rad * (angle - 90f) ) * distance;
		point.z = Mathf.Sin (Mathf.Deg2Rad * (angle - 90f) ) * -distance;

		return point;
	}


}
