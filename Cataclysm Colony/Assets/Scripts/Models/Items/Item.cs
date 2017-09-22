using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ System.Serializable ]
public class Item {

	public int id;
    public string name;
    public Sprite icon;
    public string itemDescription;

    public float health;


    public float buildHours; // Total hours to complete item
    public int optimalColonistCount; // How many colonist will get 100% efficency
    public float diminishingMultiplier;

    public int[] requiredResearch;

    public int currentUpgrade;
	public List<ItemUpgrade> upgrades;

	public Item(){
		currentUpgrade = 0;
	}

}

[System.Serializable]
public class ItemUpgrade {

    public int upgradedItemID;

    public Sprite icon;
    public string name;
    public string upgradeDescription;
    public float buildHours;

    public int[] requiredResearch; // {3, 56}

	public ItemUpgrade(){
		name = "";
		upgradeDescription = "";
		buildHours = 0f;
	}
}