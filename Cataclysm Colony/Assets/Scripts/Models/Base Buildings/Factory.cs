using System.Collections;
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

[System.Serializable]
public class FactoryBuildTask : Task {

    public Item buildItem;

    public int itemBuildAmount;
	public int itemsBuiltSoFar = 0;
    public float hoursContributed = 0f;

    public FactoryBuildTask(FactoryUIData taskData) {
        buildItem = taskData.selectedItem;
        itemBuildAmount = taskData.buildCount;
        buildItem.currentUpgrade = taskData.selectedUpgrade;
    }
    public FactoryBuildTask(Item item, int buildAmount)
    {
        buildItem = item;
        itemBuildAmount = buildAmount;
        buildItem.currentUpgrade = item.currentUpgrade;
    }

    public float GetHoursRemaining(){

		float totalHours = buildItem.buildHours * itemBuildAmount;

        if (buildItem.currentUpgrade != null)
			totalHours += (buildItem.upgrades[buildItem.currentUpgrade].buildHours * itemBuildAmount);

		return (totalHours - hoursContributed) / allocatedColonists.Count;
	}

}