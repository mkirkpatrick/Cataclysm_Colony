using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUI : MonoBehaviour {

    public FactoryController factoryController;

    //UI sections
    public Transform taskContentArea;
    public Transform itemContentArea;
    public FactoryUIDescription descriptionArea;
    public FactoryUIBuildOptions buildOptionsArea;

    //Prefabs
    public Button itemButtonPrefab;
    public Button upgradeButtonPrefab;
    public Button taskButtonPrefab;

    //UI Data
    public FactoryBuildTask selectedTask;
    public Item selectedItem;

    void Start() {
        
    }
    void Update() {
        if ( Input.GetKeyDown(KeyCode.Escape) )
            gameObject.SetActive(false);
    }

    void OnEnable() {

        selectedItem = null;
        selectedTask = null;

        if (factoryController == null)
            factoryController = GameController.Instance.baseController.factoryController;

        UIController.Instance.lockOtherInput = true;

        if (factoryController.factoryData.currentBuildTasks.Count > 0)
            UpdateTaskList();

        UpdateItemList();
        
    }
    void OnDisable() {
        UIController.Instance.lockOtherInput = false;
    }

    //Update UI sections
    public void UpdateTaskList() {
        foreach (FactoryBuildTask task in factoryController.factoryData.currentBuildTasks) {
            Button newTaskButton = Instantiate(taskButtonPrefab, taskContentArea);
            newTaskButton.GetComponent<FactoryTaskButton>().Init(task);
        }
    }
    public void UpdateItemList()
    {
        ResetItemList();

        foreach (Item item in GameController.Instance.databaseController.items)
        {
            Button newItemButton = Instantiate(itemButtonPrefab, itemContentArea) as Button;
            newItemButton.GetComponent<FactoryItemButton>().Init(item);
        }
    }
    public void ShowSelectedItem() {
        descriptionArea.gameObject.SetActive(true);
        UpdateDescription ();
        UpdateBuildOptions();

    }
	public void UpdateDescription(){
		descriptionArea.itemImage.sprite = selectedTask.buildItem.icon;
		descriptionArea.itemName.text = selectedTask.buildItem.name;
		descriptionArea.itemDescription.text = selectedTask.buildItem.itemDescription;
		descriptionArea.upgradeName.text = selectedTask.buildItem.currentUpgrade.name;
		descriptionArea.upgradeDescription.text = selectedTask.buildItem.currentUpgrade.upgradeDescription;
		descriptionArea.hoursRemaining.text = selectedTask.GetHoursRemaining ().ToString();
	}
    public void UpdateBuildOptions() {

        ResetUpgradeList();

        ItemUpgrade[] upgrades = DatabaseController.Instance.GetAvailableItemUpgrades(selectedTask.buildItem);
        foreach (ItemUpgrade upgrade in upgrades)
        {
            Button newUpgradeButton = Instantiate(upgradeButtonPrefab, buildOptionsArea.upgradesContainer);
            newUpgradeButton.GetComponent<FactoryUpgradeButton>().Init(upgrade);
        }
    }

    //Reset UI data
    public void ResetItemList()
    {
        foreach (Transform childButton in itemContentArea.transform)
        {
            if (childButton.name == "Item Button(Clone)")
                Destroy(childButton.gameObject);
        }
    }
    public void ResetUpgradeList()
    {
        foreach (Transform childButton in buildOptionsArea.upgradesContainer)
            Destroy(childButton.gameObject);
    }

}
