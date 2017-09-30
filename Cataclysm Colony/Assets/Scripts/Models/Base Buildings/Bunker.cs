using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Bunker : Building {

    public Bunker() {
        buildingName = "Bunker";
        totalConstructionHours = 600;
        constructedProgress = totalConstructionHours;
        totalColonistCapacity = 100;
        allocatedColonists = new List<Colonist>();
    }
}
