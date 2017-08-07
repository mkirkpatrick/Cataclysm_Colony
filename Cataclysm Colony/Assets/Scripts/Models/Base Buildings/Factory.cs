﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Factory : Building {

	public List<FactoryBuildTask> currentBuildTasks;
	public List<Item> inventory;

    public Factory()
    {
        this.buildingName = "Factory";
        this.totalColonistCapacity = 100;
        this.allocatedColonists = new List<Colonist>();
    }

    public void AddBuildTask(Item item, int itemAmount, int colonistCount) {
        FactoryBuildTask newBuildTask = new FactoryBuildTask(item, itemAmount, colonistCount);
    }

}

[System.Serializable]
public class FactoryBuildTask : Task {

    public Item buildItem;

    public int itemBuildAmount;
    public float hoursContributed = 0f;

    public FactoryBuildTask(Item item, int amount, int colonistCount) {
        buildItem = item;
        itemBuildAmount = amount;
    }

}