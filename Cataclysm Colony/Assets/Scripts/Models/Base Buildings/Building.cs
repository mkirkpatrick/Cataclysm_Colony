using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Building {

	public enum BuildingStatus{ UnderConstruction, Ready, Incapacitated} 
	public BuildingStatus currentStatus;

	public string buildingName;
	public int totalColonistCapacity;

    public float constructedProgress;
	public int totalConstructionHours;

	public Plot plot;
    

    [System.NonSerialized]
    public List<Colonist> allocatedColonists;

    public Building() {
        totalColonistCapacity = 100;
		currentStatus = BuildingStatus.UnderConstruction;
    }

    public void AllocateColonist(Colonist col) {

    }

}

