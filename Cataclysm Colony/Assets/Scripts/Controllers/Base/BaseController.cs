using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {

    public Base baseData;
	public GameObject base_obj;

    //Prefabs
    public GameObject basePrefab;

	public ConstructionController constructionController;
	public PlotController plotController;
    public FactoryController factoryController;
    public LaboratoryController laboratoryController;

	void Awake(){
		baseData = new Base();
	}

	void Start () {

        //Create views and containers
        base_obj = Instantiate(basePrefab);
		plotController.CreatePlotObjects ();
        ShowBase( base_obj );

        //Construction Tests ?????????
        ConstructionTask newTask = new ConstructionTask(baseData.buildings[1]);
        GameController.Instance.colonistController.AllocateColonistsToTask(newTask, 40);
        constructionController.constructionTaskList.Add(newTask);

        newTask = new ConstructionTask(baseData.buildings[2]);
        GameController.Instance.colonistController.AllocateColonistsToTask(newTask, 60);
        constructionController.constructionTaskList.Add(newTask);

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

		Plot_gameobj plotParent = plotController.plots[building.plot.plotId];

		plotParent.building_obj = build_obj.GetComponent<Building_gameobj>();
		build_obj.transform.position += plotParent.transform.position;
		build_obj.transform.eulerAngles += plotParent.transform.eulerAngles;
    }

	public void AllocateColonistsToBuilding(Building building, int count){
		for (int i = 0; i < count; i++)
		{
			Colonist idleColonist = GameController.Instance.colonistController.GetIdleColonist();
			building.allocatedColonists.Add (idleColonist);
		}
	}
}
