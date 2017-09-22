using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Laboratory : Building {

	public List<FactoryBuildTask> currentBuildTasks;
	public List<Item> inventory;

	public Laboratory() {
		this.buildingName = "Laboratory";
		this.totalColonistCapacity = 100;
		this.allocatedColonists = new List<Colonist>();
		this.currentBuildTasks = new List<FactoryBuildTask>();
	}

}
