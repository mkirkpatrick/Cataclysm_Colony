using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUI : MonoBehaviour {

    public FactoryController factoryController;
    public Factory factoryData;

    void Start() {
        factoryController = GameController.Instance.baseController.factoryController;
        factoryData = factoryController.factoryData;
    }

}
