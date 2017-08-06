using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Bunker : Building {

    public Bunker() {
        this.buildingName = "Bunker";
        this.totalColonistCapacity = 100;
        this.allocatedColonists = new List<Colonist>();
    }
}
