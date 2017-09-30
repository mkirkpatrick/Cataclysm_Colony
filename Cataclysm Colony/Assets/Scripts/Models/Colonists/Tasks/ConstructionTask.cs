using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConstructionTask : Task
{

    public Building building;

    public int totalHours = 0;
    public float hoursContributed = 0;

    public ConstructionTask(Building build)
    {
        allocatedColonists = new List<Colonist>();
        building = build;
        totalHours = building.totalConstructionHours;
    }

    public float GetHoursRemaining()
    {
        float hours = 0;
        //Do Stuff
        return hours;
    }

}
