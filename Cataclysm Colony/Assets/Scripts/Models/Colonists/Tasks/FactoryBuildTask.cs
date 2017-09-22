using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
