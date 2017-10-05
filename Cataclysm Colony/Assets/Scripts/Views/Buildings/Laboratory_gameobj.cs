using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laboratory_gameobj : Building_gameobj {

    LaboratoryController laboratoryController;

    protected override void Start()
    {
        base.Start();
        laboratoryController = GameController.Instance.baseController.laboratoryController;
	}
}
