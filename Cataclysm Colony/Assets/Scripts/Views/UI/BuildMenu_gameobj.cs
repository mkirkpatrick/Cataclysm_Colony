using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu_gameobj : MonoBehaviour {

    public Canvas buildMenuCanvas;

	// Use this for initialization
	void Awake () {
        buildMenuCanvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonPress(int buttonID) {
        Debug.Log(buttonID);
    }
}
