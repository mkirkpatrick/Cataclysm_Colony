using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_gameobj : MonoBehaviour {

    public BaseController baseController;

	public Transform plotContainer;

	void Start(){
        baseController = GameController.Instance.baseController;
	}
}
