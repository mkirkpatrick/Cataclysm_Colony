using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour {

    public static DatabaseController Instance { get; protected set; }

    public List<Item> items;
    public List<ItemUpgrade> itemUpgrades;

    void Start() {
        if (Instance == null) // check to see if the instance has a reference
        {
            Instance = this; // if not, give it a reference to this class...
        }
        else Destroy(this.gameObject);

    }


    public Item GetItemByName(string name) {
        foreach (Item item in items)
        {
            if (item.name == name)
				return CreateNewItemCopy( item );
        }
        return null;
    }

    public ItemUpgrade[] GetAvailableItemUpgrades(Item item)
    {
        List<ItemUpgrade> upgrades = new List<ItemUpgrade>();

        foreach (ItemUpgrade itemUpgrade in itemUpgrades)
        {
            if (itemUpgrade.upgradedItemID == item.id)
                upgrades.Add(itemUpgrade);
        }
        return upgrades.ToArray();
    }

	private Item CreateNewItemCopy(Item item){
		Item newItem = new Item();
		newItem.name = item.name;
		newItem.icon = item.icon;
		newItem.itemDescription = item.itemDescription;
		newItem.health = item.health;
			
		return newItem;
	}
}
