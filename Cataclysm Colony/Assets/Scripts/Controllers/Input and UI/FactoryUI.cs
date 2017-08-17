using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUI : MonoBehaviour {

    public FactoryController factoryController;

    public Transform taskContentArea;
    public GameObject taskButtonPrefab;

    public Transform itemContentArea;
    public GameObject itemButtonPrefab;

    void Start() {
        

    }
    void Update() {
        
    }

    void OnEnable() {

        if (factoryController == null)
            factoryController = GameController.Instance.baseController.factoryController;

        if (factoryController.factoryData.currentBuildTasks.Count > 0)
            UpdateTaskList();

        UpdateItemList();
    }

    public void UpdateTaskList() {
        foreach (FactoryBuildTask task in factoryController.factoryData.currentBuildTasks) {
            GameObject newTaskButton = Instantiate(taskButtonPrefab, taskContentArea);
            newTaskButton.GetComponent<FactoryTaskButton>().Init(task);
        }
    }
    public void UpdateItemList()
    {
        foreach (Item item in GameController.Instance.databaseController.items)
        {
            GameObject newItemButton = Instantiate(itemButtonPrefab, itemContentArea);
            newItemButton.GetComponent<FactoryItemButton>().Init(item);
        }
    }
}
