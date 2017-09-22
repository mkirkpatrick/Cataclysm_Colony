﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Factory : Building {

	public List<FactoryBuildTask> currentBuildTasks;
	public List<Item> inventory;

    public Factory() {
        this.buildingName = "Factory";
        this.totalColonistCapacity = 100;
        this.allocatedColonists = new List<Colonist>();
        this.currentBuildTasks = new List<FactoryBuildTask>();
    }

}