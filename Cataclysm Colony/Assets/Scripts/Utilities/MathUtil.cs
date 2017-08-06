using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtil {

    public static Vector2 GetPointOnCircle(float radius, float segmentNum, float totalSegments, bool halfSegOffset = false) {

        float ratio = segmentNum / totalSegments;

        float angle = (ratio * 360) - 90;

        if (halfSegOffset)
            angle += 360 / (totalSegments * 2);

        float x = radius * Mathf.Cos( angle * Mathf.PI / 180);
        float y = -radius * Mathf.Sin( angle * Mathf.PI / 180);

        return new Vector2(x,y);
    }

    public static Vector2 GetWallJointPosition(float radius, int segmentNum, int totalSegments) {
        Vector2 point = new Vector2();

        if (segmentNum == -1)
            segmentNum = totalSegments - 1;

        float jointRadius = radius / Mathf.Cos(360 / (2 * totalSegments) * Mathf.PI / 180);

        if (totalSegments == 16)
            point = GetPointOnCircle(jointRadius, segmentNum, totalSegments, false);
        else
            point = GetPointOnCircle( jointRadius, segmentNum, totalSegments, true);

        return point;
    }


}
