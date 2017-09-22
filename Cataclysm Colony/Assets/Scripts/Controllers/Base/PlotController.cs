using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotController : MonoBehaviour {

	public List<Plot_gameobj> plots;

	private MouseController mouseController;
	private GameObject baseObj;

	public GameObject plotPrefab;

	void Awake(){
		mouseController = GameController.Instance.mouseController;

	}

	// Use this for initialization
	void Start () {
		
		plots = new List<Plot_gameobj> ();
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

	public void CreatePlotObjects(){

		baseObj = GameController.Instance.baseController.base_obj;

		foreach(Plot plot in GameController.Instance.baseController.baseData.plots ) {
			GameObject newPlot = Instantiate (plotPrefab, GetPlotPosition(plot), Quaternion.identity, baseObj.GetComponent<Base_gameobj>().plotContainer);
			Vector3 newRotation = new Vector3 (0, GetPlotAngle (plot), 0);
			newPlot.transform.eulerAngles = newRotation;
			newPlot.GetComponent<Plot_gameobj> ().plotData = plot;
			plots.Add (newPlot.GetComponent<Plot_gameobj>());
		}
	}

	public Vector3 GetPlotPosition(Plot plotData){
		if (plotData.plotType == Plot.PlotType.Bunker)
			return new Vector3 (0, 0, 0);
		else if (plotData.plotType == Plot.PlotType.Tier1)
			return MathUtil.GetPointOnCircle ((plotData.plotNum-1) * 90f, 50f);
		else if (plotData.plotType == Plot.PlotType.Tier1Wall)
			return MathUtil.GetPointOnCircle (plotData.plotNum * 90f, 75f);
		else if (plotData.plotType == Plot.PlotType.Tier2)
			return MathUtil.GetPointOnCircle (plotData.plotNum * 30f, 100f);
		else
			return new Vector3 (0, 0, 0);
	}
	public float GetPlotAngle(Plot plotData){
		if (plotData.plotType == Plot.PlotType.Bunker)
			return 0f;
		else if (plotData.plotType == Plot.PlotType.Tier1)
			return (plotData.plotNum-1) * 90f;
		else if (plotData.plotType == Plot.PlotType.Tier1Wall)
			return plotData.plotNum * 90f;
		else if (plotData.plotType == Plot.PlotType.Tier2)
			return plotData.plotNum * 30f;
		else
			return 0f;
	}
		
}
