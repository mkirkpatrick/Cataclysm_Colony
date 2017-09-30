using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Laboratory : Building {

	public List<FactoryBuildTask> currentBuildTasks;
	public List<Item> inventory;

	public Laboratory() {
		buildingName = "Laboratory";
		totalConstructionHours = 600;
        constructedProgress = totalConstructionHours;
        totalColonistCapacity = 100;
		allocatedColonists = new List<Colonist>();
		currentBuildTasks = new List<FactoryBuildTask>();
	}

}
