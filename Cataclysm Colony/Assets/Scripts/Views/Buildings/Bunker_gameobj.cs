using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker_gameobj : Building_gameobj {

	public bool baseStatus = false;

    void Start() {
        
    }

	void OnMouseDown()
	{
		if ((UIController.Instance.lockOtherInput == false) && (buildingData.currentStatus == Building.BuildingStatus.Ready))
			baseStatus = true;

	}
}
