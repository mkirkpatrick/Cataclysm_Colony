using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WallJoint {

    public int tier;
    public int arrayPos;
    public string type;

    public WallJoint() {
        type = "None";
    }
}
