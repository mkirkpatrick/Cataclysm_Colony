using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker_gameobj : Building_gameobj {

    protected override void Start() {
        base.Start();
    }

	void OnMouseDown()
	{
        if ((UIController.Instance.lockOtherInput == false) && (buildingData.currentStatus == Building.BuildingStatus.Ready))
            baseController.showBaseStatus = !baseController.showBaseStatus;

    }
}
