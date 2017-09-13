using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	public InventoryController inventoryController;

	public Dictionary<Item,int> itemCounts;

	public Transform itemsContainer;

	//Prefabs
	public Button invenoryButton;
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape) )
			gameObject.SetActive(false);
	}
	void OnEnable(){
		if (inventoryController == null)
			inventoryController = GameController.Instance.inventoryController;

		UIController.Instance.lockOtherInput = true;

		UpdateItems ();

	}
	void OnDisable(){
		UIController.Instance.lockOtherInput = false;
	}

	public void UpdateItems(){
		ResetInventory ();

		itemCounts = new Dictionary<Item,int>();

		foreach(Item item in inventoryController.totalItems){
			if (itemCounts.ContainsKey(item)){
				itemCounts[item] = itemCounts[item]+1;
			} else {
				itemCounts[item] = 1;
			}
		}

		foreach (Item item in itemCounts.Keys) {
			Button newButton = Instantiate (invenoryButton, itemsContainer.transform);
			newButton.GetComponent<ItemInventoryButton> ().Init (item, itemCounts[item]);
		}
			
	}

	public void ResetInventory()
	{
		foreach (Transform childButton in itemsContainer.transform)
		{
			if (childButton.name == "Inventory Item Button(Clone)")
				Destroy(childButton.gameObject);
		}
	}
}
