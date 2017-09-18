using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour {

	public enum BaseTiers {Bunker, InnerPlot, InnerWall, OuterPlot, OuterWall}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log( GetBaseTier( GameController.Instance.mouseController.distanceFromOrigin ) );
	}

	public BaseTiers GetBaseTier(float mouseDistance){

		if (mouseDistance < 30f)
			return BaseTiers.Bunker;
		else if (mouseDistance < 70f)
			return BaseTiers.InnerPlot;
		else
			return BaseTiers.Bunker;
	
	}
		
}
