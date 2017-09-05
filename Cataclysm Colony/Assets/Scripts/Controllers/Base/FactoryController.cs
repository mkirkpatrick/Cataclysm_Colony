using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour {

    public Factory factoryData;

    void Start() {
        
    }
    void Update() {
        foreach (FactoryBuildTask task in factoryData.currentBuildTasks) {
            task.hoursContributed += (( Time.deltaTime * task.allocatedColonists.Count) / 60f);
        }
    }

    public void AddFactoryTask(FactoryUIData taskData) {
        FactoryBuildTask newFactoryTask = new FactoryBuildTask(taskData);

        newFactoryTask.allocatedColonists = new List<Colonist>();
        for (int i = 0; i < taskData.colonistAssignedCount; i++) {
            Colonist idleColonist = GameController.Instance.colonistController.GetIdleColonist();
            GameController.Instance.colonistController.AllocateColonistToTask(idleColonist, newFactoryTask);
        }

        factoryData.currentBuildTasks.Add(newFactoryTask);
    }
    public void AddFactoryTask(Item item, int colonistsAssigned, int amountToBuild)
    {
        FactoryBuildTask newFactoryTask = new FactoryBuildTask(item, amountToBuild);

        for (int i = 0; i < colonistsAssigned; i++)
        {
            Colonist idleColonist = GameController.Instance.colonistController.GetIdleColonist();
            GameController.Instance.colonistController.AllocateColonistToTask(idleColonist, newFactoryTask);
        }

        factoryData.currentBuildTasks.Add(newFactoryTask);
    }
}
