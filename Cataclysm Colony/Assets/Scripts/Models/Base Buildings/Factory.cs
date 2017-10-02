using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Factory : Building {

	public List<FactoryBuildTask> currentBuildTasks;
	public List<Item> inventory;

    public Factory() {
        buildingName = "Factory";
		totalConstructionHours = 300;
        totalColonistCapacity = 100;
        allocatedColonists = new List<Colonist>();
        currentBuildTasks = new List<FactoryBuildTask>();
    }

}