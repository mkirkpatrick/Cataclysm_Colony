using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class ColonistManager {

	public enum JobType { None, Builder, Engineer, Scientist, Medic, Farmer, Scout, Soldier}

    [System.NonSerialized]
    private Base colonistBase;

	public List<Colonist> colonists;
	public List<Colonist> idleColonists;

	public float[] colonySkills;

	public ColonistManager(int colCount) {
        colonists = new List<Colonist>();
		idleColonists = new List<Colonist>();
        colonySkills = new float[7];
        CreateColonists(colCount);
    }

    private void CreateColonists(int count)
    {
        for (int i = 0; i < count; i++)
        {
            colonists.Add( new Colonist() );
        }
    }
    
	//Colonist Assignment Functions

	public Colonist GetIdleColonist(){

		Colonist col;

		if (idleColonists.Count > 0) {
			col = idleColonists [0];
			idleColonists.RemoveAt(0);
			WorldController.Instance.world.baseData.buildings [0].allocatedColonists.Remove (col);
			return col;
		} else {
			Debug.Log ("No idle colonists");
			return null;
		}
	}

	public void SetIdleColonist(Colonist col) {
		AllocateColonistToBuilding (col, WorldController.Instance.world.baseData.buildings [0]);
		col.currentJobType = JobType.None;
		idleColonists.Add (col);
	}

	public void AllocateColonistToBuilding(Colonist colonist, Building building)
    {
        if (building.allocatedColonists.Count < building.totalColonistCapacity)
        {
			//Remove from old building first
			if (colonist.assignedBuilding != null)
				colonist.assignedBuilding.allocatedColonists.Remove (colonist);

            building.allocatedColonists.Add(colonist);
            colonist.assignedBuilding = building;
        }
            
    }
}
