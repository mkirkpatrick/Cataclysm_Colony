using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour {

    public Factory factoryData;

    void Start() {
        
    }
    void Update() {
		UpdateTaskHours ();
    }

    public void AddFactoryTask(FactoryUIData taskData) {
        FactoryBuildTask newFactoryTask = new FactoryBuildTask(taskData);

        newFactoryTask.allocatedColonists = new List<Colonist>();
        GameController.Instance.colonistController.AllocateColonistsToTask(newFactoryTask, taskData.colonistAssignedCount);

        factoryData.currentBuildTasks.Add(newFactoryTask);
    }
    public void AddFactoryTask(Item item, int colonistsAssigned, int amountToBuild)
    {
        FactoryBuildTask newFactoryTask = new FactoryBuildTask(item, amountToBuild);

        GameController.Instance.colonistController.AllocateColonistsToTask(newFactoryTask, colonistsAssigned);

        factoryData.currentBuildTasks.Add(newFactoryTask);
    }
	public void RemoveFactoryTask(FactoryBuildTask task) {

		foreach (Colonist colonist in task.allocatedColonists) {
			GameController.Instance.colonistController.SetIdleColonist (colonist);
		}

		factoryData.currentBuildTasks.Remove (task);
		UIController.Instance.factoryUI.UpdateTaskList ();
	}

	public void UpdateTaskHours(){
		List<FactoryBuildTask> removalList = new List<FactoryBuildTask> ();

		foreach (FactoryBuildTask task in factoryData.currentBuildTasks) {
			task.hoursContributed += (task.allocatedColonists.Count * Time.deltaTime / 60f);

			int newItemCount = Mathf.FloorToInt (task.hoursContributed / task.buildItem.buildHours);
			if ((newItemCount - task.itemsBuiltSoFar) == 1) {
				BuildItem (task.buildItem);
				task.itemsBuiltSoFar++;
			}

			if (task.itemsBuiltSoFar == task.itemBuildAmount)
				removalList.Add(task);
		}

		foreach (FactoryBuildTask task in removalList)
			RemoveFactoryTask (task);
	
	}

	public void BuildItem(Item item){
		Item newItem = DatabaseController.Instance.GetItemByName (item.name);
		GameController.Instance.inventoryController.totalItems.Add (newItem);
		GameController.Instance.inventoryController.availableItems.Add (newItem);
		if (UIController.Instance.inventoryUI.gameObject.activeSelf == true)
			UIController.Instance.inventoryUI.UpdateItems ();
	}
}
