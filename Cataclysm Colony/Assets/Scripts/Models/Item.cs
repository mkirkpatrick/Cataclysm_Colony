using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public ItemUpgrade currentUpgrade;

}

[System.Serializable]
public class ItemUpgrade {

    public int upgradedItemID;

    public string name = "Laser Rifle";
    public string upgradeDescription;

    public int[] requiredResearch; // {3, 56}


}