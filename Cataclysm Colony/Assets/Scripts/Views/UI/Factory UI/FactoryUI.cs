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
    public GameObject itemsContainer;
    public Button itemButtonPrefab;
    public Button upgradeButtonPrefab;
    public Button taskButtonPrefab;

    //UI Data
    public FactoryUIData factoryUIData;

    void Start() {
        
    }
    void Update() {
        if ( Input.GetKeyDown(KeyCode.Escape) )
            gameObject.SetActive(false);
    }


    void OnEnable() {

        if (factoryController == null)
            factoryController = GameController.Instance.baseController.factoryController;

        descriptionArea.gameObject.SetActive(false);
        buildOptionsArea.gameObject.SetActive(false);

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
        ResetTaskList();
        foreach (FactoryBuildTask task in factoryController.factoryData.currentBuildTasks) {
            Button newTaskButton = Instantiate(taskButtonPrefab, taskContentArea);
            newTaskButton.GetComponent<FactoryTaskButton>().Init(task);
        }
    }
    public void UpdateItemList()
    {
        ResetItemList();

        GameObject itemContainer = Instantiate(itemsContainer, itemContentArea) as GameObject;

        foreach (Item item in GameController.Instance.databaseController.items)
        {
            Button newItemButton = Instantiate( itemButtonPrefab, itemContainer.transform.Find("Item Buttons") ) as Button;
            newItemButton.GetComponent<FactoryItemButton>().Init(item);
        }
    }
    public void ShowSelectedItem() {
        descriptionArea.gameObject.SetActive(true);
        buildOptionsArea.gameObject.SetActive(true);
        UpdateDescription ();
        UpdateBuildOptions();

    }
    public void ShowSelectedTask() {
        descriptionArea.gameObject.SetActive(true);
        buildOptionsArea.gameObject.SetActive(true);
        UpdateDescription();
        UpdateBuildOptions();
    }
    public void UpdateDescription(){

        descriptionArea.hoursRemaining.gameObject.transform.parent.gameObject.SetActive(false);
        descriptionArea.itemImage.sprite = factoryUIData.selectedItem.icon;
        descriptionArea.itemName.text = factoryUIData.selectedItem.name;
        descriptionArea.itemDescription.text = factoryUIData.selectedItem.itemDescription;
		descriptionArea.upgradeName.text = factoryUIData.selectedItem.upgrades[factoryUIData.selectedUpgrade].name;
		descriptionArea.upgradeDescription.text = factoryUIData.selectedItem.upgrades[factoryUIData.selectedUpgrade].upgradeDescription;

	}
    public void UpdateBuildOptions() {

        ResetUpgradeList();

		for (int i = 0; i < factoryUIData.selectedItem.upgrades.Count; i++)
        {
            Button newUpgradeButton = Instantiate(upgradeButtonPrefab, buildOptionsArea.upgradesContainer);
			newUpgradeButton.GetComponent<FactoryUpgradeButton>().Init(factoryUIData.selectedItem, i);
        }
    }

    //Change UI Data
    public void ChangeBuildCount(int number) {
        int newNum;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            newNum = factoryUIData.buildCount + (number * 10);
        else
            newNum = factoryUIData.buildCount += number;

        factoryUIData.buildCount = newNum;

        if (factoryUIData.buildCount <= 0)
            factoryUIData.buildCount = 1;
    }
    public void ChangeColonistCount(int number) {

        int newNum;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) )
            newNum = factoryUIData.colonistAssignedCount + (number * 10);
        else
            newNum = factoryUIData.colonistAssignedCount + number;

        factoryUIData.colonistAssignedCount = Mathf.Clamp(newNum, 1, GameController.Instance.baseController.baseData.idleColonists.Count);
}

    //Reset UI data
    public void ResetTaskList()
    {
        foreach (Transform childButton in taskContentArea.transform)
        {
            if (childButton.name == "Task Button(Clone)")
                Destroy(childButton.gameObject);
        }
    }
    public void ResetItemList()
    {
        foreach (Transform childButton in itemContentArea.transform)
        {
            if (childButton.name == "Items Container(Clone)")
                Destroy(childButton.gameObject);
        }
    }
    public void ResetUpgradeList()
    {
        foreach (Transform childButton in buildOptionsArea.upgradesContainer)
            Destroy(childButton.gameObject);
    }
    public void ResetUIData() {
        factoryUIData.selectedItem = null;
        factoryUIData.selectedTask = null;
    }

    public void AddBuildTask() {
        factoryController.AddFactoryTask(factoryUIData);
        UpdateTaskList();
    }
}

[System.Serializable]
public class FactoryUIData {
    public FactoryBuildTask selectedTask;
    public Item selectedItem;
    public int selectedUpgrade;

    public int currentInventoryCount;
    public int buildCount;
    public int colonistAssignedCount;

    public FactoryUIData(Item item) {
        selectedItem = item;
        buildCount = 1;
        colonistAssignedCount = 1;
    }
    public FactoryUIData(FactoryBuildTask task)
    {
        selectedTask = task;
        selectedItem = selectedTask.buildItem;
        selectedUpgrade = selectedItem.currentUpgrade;
        buildCount = selectedTask.itemBuildAmount;
        colonistAssignedCount = selectedTask.allocatedColonists.Count;
    }
}