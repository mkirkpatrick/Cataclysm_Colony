using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUI : MonoBehaviour {

    public FactoryController factoryController;

    public Transform taskContentArea;
    public GameObject taskButtonPrefab;

    void Start() {
        factoryController = GameController.Instance.baseController.factoryController;

    }
    void Update() {
        
    }

    void OnEnable() {
        if (factoryController.factoryData.currentBuildTasks != null)
            UpdateTaskList();
    }

    public void UpdateTaskList() {
        foreach (FactoryBuildTask task in factoryController.factoryData.currentBuildTasks) {
            GameObject newTaskButton = Instantiate(taskButtonPrefab, taskContentArea);
            newTaskButton.GetComponent<FactoryTaskButton>().Init(task);
        }
    }
}
