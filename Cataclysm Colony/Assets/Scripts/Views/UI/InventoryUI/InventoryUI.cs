using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	public InventoryController inventoryController;

	public Dictionary<string,int> itemCounts;

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

		itemCounts = new Dictionary<string,int>();
		Debug.Log (inventoryController.totalItems.Count);

		foreach(Item item in inventoryController.totalItems){
			if (itemCounts.ContainsKey(item.name)){
				itemCounts[item.name] = itemCounts[item.name]+1;
			} else {
				itemCounts[item.name] = 1;
			}
		}

		foreach (string itemName in itemCounts.Keys) {
			Button newButton = Instantiate (invenoryButton, itemsContainer.transform);
			Item newItem = DatabaseController.Instance.GetItemByName (itemName);
			newButton.GetComponent<ItemInventoryButton> ().Init (newItem, itemCounts[itemName]);
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
