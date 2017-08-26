using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUI : MonoBehaviour {

    public FactoryController factoryController;

    public Transform taskContentArea;
    public Button taskButtonPrefab;

    public Transform itemContentArea;
    public Button itemButtonPrefab;

    public FactoryUIDescription descriptionArea;
    public FactoryUIBuildOptions buildOptionsArea;

    public Button upgradeButtonPrefab;

    public FactoryBuildTask selectedTask;
    public Item selectedItem;

    void Start() {
        
    }
    void Update() {
        
    }

    void OnEnable() {

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
    public void ResetItemList() {
        foreach (Transform childButton in itemContentArea.transform) {
            if (childButton.name == "Item Button(Clone)")
                Destroy(childButton.gameObject);
        }
    }
    public void ResetUpgradeList()
    {
        foreach (Transform childButton in buildOptionsArea.upgradesContainer)
                Destroy(childButton.gameObject);
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

}
