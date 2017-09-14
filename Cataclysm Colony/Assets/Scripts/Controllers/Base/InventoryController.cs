using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	public List<Item> totalItems;
	public List<Item> availableItems;

	void Start(){
		
	}

	public int GetItemCount(Item item){
		int itemCount = 0;

		foreach (Item i in totalItems) {
			if (i.name == item.name)
				itemCount++;
		}

		return itemCount;
	}
}
