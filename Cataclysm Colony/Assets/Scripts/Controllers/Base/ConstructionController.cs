using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionController : MonoBehaviour {

	public List<ConstructionTask> constructionTaskList;

    void Start() {
        
    }

	public void Update(){
		UpdateConstruction ();
	}

	public void UpdateConstruction(){
		for (int i = 0; i < constructionTaskList.Count; i++) {
            constructionTaskList[i].hoursContributed += constructionTaskList[i].allocatedColonists.Count * Time.deltaTime / 60f;
            constructionTaskList[i].building.constructedProgress = constructionTaskList[i].hoursContributed;
            //Check for completion
            if (constructionTaskList[i].hoursContributed >= constructionTaskList[i].totalHours)
                CompleteConstructionTask(constructionTaskList[i]);
        }
	}
    public void CompleteConstructionTask(ConstructionTask task) {
        foreach (Colonist colonist in task.allocatedColonists) {
            GameController.Instance.colonistController.SetIdleColonist(colonist);
        }
        task.building.currentStatus = Building.BuildingStatus.Ready;
        constructionTaskList.Remove(task);
    }
}
