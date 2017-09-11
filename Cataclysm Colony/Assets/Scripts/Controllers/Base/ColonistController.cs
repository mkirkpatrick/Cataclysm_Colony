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

	public void AllocateColonistToTask(Colonist colonist, Task task)
	{
		//Remove from old task first
		if (colonist.assignedTask != null)
			colonist.assignedTask.allocatedColonists.Remove(colonist);

        task.allocatedColonists.Add(colonist);
		colonist.assignedTask = task;

	}
}