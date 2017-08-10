using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_gameobj : Building_gameobj {

    FactoryController factoryController;

    void Start() {
        factoryController = GameController.Instance.baseController.factoryController;
    }
}
