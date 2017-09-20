using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {

    public Base baseData;
	public GameObject base_obj;

    //Prefabs
    public GameObject basePrefab;

    public FactoryController factoryController;

	void Awake(){
		baseData = new Base();
	}

	void Start () {

        //Create views and containers
        base_obj = Instantiate(basePrefab);

        ShowBase( base_obj );
	}
	
	// Update is called once per frame
	void Update () {
   
    }

	public void ShowBase(GameObject baseObj){
		
		foreach (Building building in baseData.buildings) {
            
            PlaceBuilding (building, baseObj);
		}

	}
	public void PlaceBuilding(Building building, GameObject parent){
		GameObject prefab = Resources.Load("Prefabs/Buildings/" + building.buildingName) as GameObject;
        GameObject build_obj = Instantiate (prefab, parent.transform);
        build_obj.GetComponent<Building_gameobj>().buildingData = building;

        GameObject plotParent = BaseUtil.GetPlotObject(building.plot, base_obj);
        plotParent.GetComponent<Plot_gameobj>().building_obj = build_obj.GetComponent<Building_gameobj>();
        build_obj.transform.position = plotParent.transform.position;
    }
}
