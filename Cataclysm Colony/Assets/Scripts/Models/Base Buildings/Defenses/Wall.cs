using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wall {

    public int tier;
    public int arrayPos;
    public string type;
    public float health;

    public Wall() {
        type = "None";
        health = 0f;
    }
}
