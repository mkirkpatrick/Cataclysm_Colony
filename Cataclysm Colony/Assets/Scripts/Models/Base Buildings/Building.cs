using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Building {

	public string buildingName;
    public Plot plot;

    public int totalColonistCapacity;

    [System.NonSerialized]
    public List<Colonist> allocatedColonists;

    public Building() {
        totalColonistCapacity = 100;
    }

    public void AllocateColonist(Colonist col) {

    }

}

