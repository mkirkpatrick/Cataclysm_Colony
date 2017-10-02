using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ResearchTask : Task
{
    public ResearchItem researchItem;

    public float hoursContributed = 0f;

    public ResearchTask(ResearchItem item)
    {
        researchItem = item;
    }

    public float GetHoursRemaining()
    {
        return (researchItem.totalHours - hoursContributed) / allocatedColonists.Count;
    }

}

