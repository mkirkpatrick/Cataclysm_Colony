using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	int id;
	string name;
	Sprite icon;
	string itemDescription;

	float health;


	float buildHours; // Total hours to complete item
	int optimalColonistCount; // How many colonist will get 100% efficency
	float diminishingMultiplier;

	int[] requiredResearch;

	ItemUpgrade currentUpgrade;

}

public class ItemUpgrade {

	int upgradedItemID;

	string name = "Laser Rifle";
	string upgradeDescription;

	int[] requiredResearch; // {3, 56}


}