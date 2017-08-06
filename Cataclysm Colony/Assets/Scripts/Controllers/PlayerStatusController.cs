using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour {

    public enum PlayerMode { Base, Commander}
    public PlayerMode playerMode;

	// Use this for initialization
	void Awake () {
        playerMode = PlayerMode.Base;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
