using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Laboratory : Building {

	public List<ResearchTask> currentResearchTasks;
    public List<int> researchProgression;

	public Laboratory() {
		buildingName = "Laboratory";
		totalConstructionHours = 300;
        totalColonistCapacity = 100;
		allocatedColonists = new List<Colonist>();
        currentResearchTasks = new List<ResearchTask>();
	}

}
