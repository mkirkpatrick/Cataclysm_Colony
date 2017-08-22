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

    public Task selectedTask;
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
            newItemButton.onClick.AddListener(newItemButton.GetComponent<FactoryItemButton>().ItemButtonAction);
        }
    }
    public void ResetItemList() {
        foreach (Transform childButton in itemContentArea.transform) {
            if (childButton.name == "Item Button(Clone)")
                Destroy(childButton.gameObject);
        }
    }

    public void ShowSelectedItem() {
        descriptionArea.gameObject.SetActive(true);
        descriptionArea.itemImage.sprite = selectedItem.icon;
        descriptionArea.itemName.text = selectedItem.name;
        descriptionArea.itemDescription.text = selectedItem.itemDescription;
    }

}
