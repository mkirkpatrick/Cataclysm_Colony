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
		foreach (ConstructionTask constructionTask in constructionTaskList) {
            constructionTask.hoursContributed += constructionTask.allocatedColonists.Count * Time.deltaTime / 60f;

            //Check for completion
            if (constructionTask.hoursContributed >= constructionTask.totalHours)
                CompleteConstructionTask(constructionTask);
        }
	}
    public void CompleteConstructionTask(ConstructionTask task) {
        foreach (Colonist colonist in task.allocatedColonists) {
            GameController.Instance.colonistController.SetIdleColonist(colonist);
        }
    }
}
