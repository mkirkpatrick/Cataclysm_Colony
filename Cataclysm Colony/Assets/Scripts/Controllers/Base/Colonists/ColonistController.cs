using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonistController : MonoBehaviour {

    public Base colonistBase;

	void Start(){
		colonistBase = GameController.Instance.baseController.baseData;
		CreateColonists(100);
	}


    public void CreateColonists(int count)
    {
        for (int i = 0; i < count; i++)
        {
			Colonist newColonist = new Colonist ();
			colonistBase.colonists.Add(newColonist);
			SetIdleColonist (newColonist);
        }
    }

    public Colonist GetIdleColonist()
    {

        Colonist col;

        if (colonistBase.idleColonists.Count > 0)
        {
            col = colonistBase.idleColonists[0];
            colonistBase.idleColonists.RemoveAt(0);
			colonistBase.buildings[0].allocatedColonists.Remove(col);
            return col;
        }
        else
        {
            Debug.Log("No idle colonists");
            return null;
        }
    }

	public void SetIdleColonist(Colonist col)
	{
		AllocateColonistToBuilding(col, colonistBase.buildings[0]);
		colonistBase.idleColonists.Add(col);
	}

	public void AllocateColonistToBuilding(Colonist colonist, Building building)
	{
		//Remove from old building first
		if (colonist.assignedBuilding != null)
			colonist.assignedBuilding.allocatedColonists.Remove(colonist);

		building.allocatedColonists.Add(colonist);
		colonist.assignedBuilding = building;

	}

    //Tasks
    //Allocate to new task removing any currently in queue
	public void AllocateColonistsToTask(Task task, int colonistCount)
	{
        for (int i = 0; i < colonistCount; i++) {
            Colonist newColonist = GetIdleColonist();
            task.allocatedColonists.Add(newColonist);
            newColonist.assignedTasks.Add(task);
        }

	}
    //Add a task on the queue
    public void AddTaskToQueue(Colonist colonist, Task task) {
        task.allocatedColonists.Add(colonist);
        colonist.assignedTasks.Add(task);
    }
}