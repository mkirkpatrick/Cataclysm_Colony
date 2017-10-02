using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laboratory_gameobj : Building_gameobj {

    LaboratoryController laboratoryController;

	// Use this for initialization
	void Start () {
        laboratoryController = GameController.Instance.baseController.laboratoryController;
	}
}
