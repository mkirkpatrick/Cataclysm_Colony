using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryController : MonoBehaviour {

    public Laboratory laboratoryData;

    void Update()
    {
        
    }

    public void AddResearchTask(ResearchItem item, int colonistCount)
    {
        ResearchTask newResearchTask = new ResearchTask(item);

        newResearchTask.allocatedColonists = new List<Colonist>();
        GameController.Instance.colonistController.AllocateColonistsToTask(newResearchTask, colonistCount);

        laboratoryData.currentResearchTasks.Add(newResearchTask);
    }
    public void RemoveResearchTask(ResearchTask task)
    {

        foreach (Colonist colonist in task.allocatedColonists)
        {
            GameController.Instance.colonistController.SetIdleColonist(colonist);
        }

        laboratoryData.currentResearchTasks.Remove(task);
        // Lab UI update ?????????
    }
    public void UpdateTaskHours()
    {
        List<ResearchTask> removalList = new List<ResearchTask>();

        foreach (ResearchTask task in laboratoryData.currentResearchTasks)
        {
            task.hoursContributed += (task.allocatedColonists.Count * Time.deltaTime / 60f);

            if (task.hoursContributed >= task.researchItem.totalHours)
                removalList.Add(task);
        }

        foreach (ResearchTask task in removalList)
            RemoveResearchTask(task);

    }

}
