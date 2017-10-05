using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_gameobj : Building_gameobj {

    FactoryController factoryController;


    protected override void Start()
    {
        base.Start();
        factoryController = GameController.Instance.baseController.factoryController;
    }
}
