using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Plot {

    public enum PlotType { Bunker, Tier1, Tier1Wall, Tier2, Tier2Wall, Wilderness}

    public PlotType plotType;
    public int plotNum;
    public Building building;

    public Plot(PlotType type, int num) {
        plotType = type;
        plotNum = num;
    }

}
