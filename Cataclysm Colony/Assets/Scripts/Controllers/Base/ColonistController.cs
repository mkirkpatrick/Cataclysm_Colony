using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonistController : MonoBehaviour {
	
	public ColonistManager colonistManager;

	public float updateTime = 0f;

    // Use this for initialization
    void Start() {
        colonistManager = WorldController.Instance.world.baseData.colonistManager;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
