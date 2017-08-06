using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ System.Serializable ]
public class Base {

	public ColonistManager colonistManager;
    public ResourceManager resourceManager;

    public List<Plot> plots;
    public List<Building> buildings;
    

    public Base(int colonistCount) {

        plots = new List<Plot>();
        InitializePlots();

        buildings = new List<Building>();
		AddBuilding( new Bunker(), plots[0] );
        AddBuilding(new Factory(), plots[1]);

        colonistManager = new ColonistManager(colonistCount);

        //Assign all colonists to Bunker and Idle to start
        foreach (Colonist col in colonistManager.colonists)
        {
            colonistManager.AllocateColonistToBuilding(col, buildings[0]);
			colonistManager.idleColonists.Add (col);
        }

    }

    private void AddBuilding(Building b, Plot plot) {
        b.plot = plot;
        plot.building = b;
        buildings.Add(b);
    }

    private void InitializePlots() {
        plots.Add(new Plot(Plot.PlotType.Bunker, 0));

        for (int i = 1; i <= 4; i++)
        {
            plots.Add(new Plot(Plot.PlotType.Tier1, i));
        }
        for (int i = 1; i <= 4; i++)
        {
            plots.Add(new Plot(Plot.PlotType.Tier1Wall, i));
        }
        for (int i = 1; i <= 12; i++)
        {
            plots.Add(new Plot(Plot.PlotType.Tier2, i));
        }
        for (int i = 1; i <= 4; i++)
        {
            plots.Add(new Plot(Plot.PlotType.Tier2Wall, i));
        }
    }
}
