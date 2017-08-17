using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_gameobj : MonoBehaviour {

	public TerrainData terrainData;
	public Sprite[] terrainSprites;

	public GameObject baseObj;

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Init(ref Base playerBase) {
        GameObject basePrefab = Resources.Load("Prefabs/Buildings/Base") as GameObject;
        baseObj = Instantiate(basePrefab, transform, true);
        baseObj.GetComponent<Base_gameobj>().baseController.baseData = playerBase;
    }

}
