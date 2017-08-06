using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{

    public List<Wall> walls;
    public List<WallJoint> wallJoints;
    public GameObject wallsContainer;
    public GameObject wallPrefab;
    public GameObject wallJointPrefab;

    // Use this for initialization
    void Start()
    {
        wallPrefab = Resources.Load("Prefabs/Buildings/Wall Parts/Wall") as GameObject;
        wallJointPrefab = Resources.Load("Prefabs/Buildings/Wall Parts/Wall Joint") as GameObject;
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init()
    {
        for (int i = 0; i < 8; i++)
        {
            walls[i].arrayPos = i;
            walls[i].tier = 1;
        }
        for (int i = 0; i < 16; i++)
        {
            walls[i+8].arrayPos = i;
            walls[i+8].tier = 2;
        }
        for (int i = 0; i < 24; i++)
        {
            walls[i+24].arrayPos = i;
            walls[i+24].tier = 3;
        }

        for (int i = 0; i < 8; i++)
        {
            wallJoints[i].arrayPos = i;
            wallJoints[i].tier = 1;
        }
        for (int i = 0; i < 16; i++)
        {
            wallJoints[i + 8].arrayPos = i;
            wallJoints[i + 8].tier = 2;
        }
        for (int i = 0; i < 24; i++)
        {
            wallJoints[i + 24].arrayPos = i;
            wallJoints[i + 24].tier = 3;
        }

        foreach (Wall wall in walls) {
            GameObject wall_obj = Instantiate(wallPrefab, wallsContainer.transform) as GameObject;
            wall_obj.GetComponent<Wall_gameobj>().wallData = wall;

            Vector2 pos = GetWallPosition(wall);
            wall_obj.transform.position = pos;
            
            wall_obj.transform.rotation = GetWallRotation(wall);
            wall_obj.transform.localScale = GetWallScale(wall, wall_obj);
        }

        foreach (WallJoint wallJoint in wallJoints)
        {
            GameObject wallJoint_obj = Instantiate(wallJointPrefab, wallsContainer.transform) as GameObject;
            wallJoint_obj.GetComponent<WallJoint_gameobj>().wallJointData = wallJoint;

            Vector2 pos = GetWallJointPosition(wallJoint);
            wallJoint_obj.transform.position = pos;
        }
    }

    public Vector2 GetWallPosition(Wall wallData) {

        int totalSeg = ((wallData.tier - 1) * 8) + 8;

        Vector2 position;
        if (wallData.tier == 2)
            position = MathUtil.GetPointOnCircle((wallData.tier * 4) + 2, wallData.arrayPos, totalSeg, true);
        else
            position = MathUtil.GetPointOnCircle((wallData.tier*4)+2, wallData.arrayPos, totalSeg);

        return position;
    }
    public Quaternion GetWallRotation(Wall wallData) {
        int totalSeg = ((wallData.tier - 1) * 8) + 8;

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = wallData.arrayPos * -(360f / totalSeg);

        if (wallData.tier == 2)
            rotationVector.z -= 11.25f;

        return Quaternion.Euler(rotationVector);
    }

    public Vector3 GetWallScale(Wall wallData, GameObject wall_obj) {

        Vector3 scale = wall_obj.transform.localScale;
        int totalSeg = ((wallData.tier - 1) * 8) + 8;

        float apothem = ((wallData.tier * 4) + 2);
        Vector2[] ends = new Vector2[2];
        ends[0] = MathUtil.GetWallJointPosition(apothem, wallData.arrayPos-1, totalSeg);
        ends[1] = MathUtil.GetWallJointPosition(apothem, wallData.arrayPos, totalSeg);

        float distance = Vector2.Distance(ends[0], ends[1]);
        scale.x = distance;

        return scale;
    }

    public Vector2 GetWallJointPosition(WallJoint wallJointData) {
        Vector2 pos;
        int totalSeg = ((wallJointData.tier - 1) * 8) + 8;
        float apothem = (wallJointData.tier * 4) + 2;
        Vector2 joint = MathUtil.GetWallJointPosition(apothem, wallJointData.arrayPos, totalSeg);

        pos = joint;

        return pos;
    }
}
