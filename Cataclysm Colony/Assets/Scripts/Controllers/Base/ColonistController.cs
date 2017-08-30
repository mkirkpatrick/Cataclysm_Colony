using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonistController : MonoBehaviour {

    private Base colonistBase;

    public float[] colonySkills;



    public List<Colonist> CreateColonists(int count)
    {
        List<Colonist> colonists = new List<Colonist>();

        for (int i = 0; i < count; i++)
        {
            colonists.Add(new Colonist());
        }
        return colonists;
    }

    public Colonist GetIdleColonist()
    {

        Colonist col;

        if (colonistBase.idleColonists.Count > 0)
        {
            col = colonistBase.idleColonists[0];
            colonistBase.idleColonists.RemoveAt(0);
            WorldController.Instance.world.baseData.buildings[0].allocatedColonists.Remove(col);
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
		AllocateColonistToBuilding(col, WorldController.Instance.world.baseData.buildings[0]);
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