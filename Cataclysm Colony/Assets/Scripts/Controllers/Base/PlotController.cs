using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour {

    public List<Plot_gameobj> plots;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Plot.PlotType GetPlotType(float mouseDistance){

		if (mouseDistance < 30f)
			return Plot.PlotType.Bunker;
		else if (mouseDistance < 70f)
			return Plot.PlotType.Tier1;
		else
			return Plot.PlotType.Bunker;
	
	}
		
}
