using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour {

    public ResourceManager resources;
	public List<Building> resourceGenerators;
	public List<Building> resourceCapacity;

    public float updateTime = 0f;


	// Use this for initialization
	void Start () {
		//GetResourceCapacity (gameObject.GetComponent<Base_gameobj> ().baseData.buildings);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateResourceTimer();
	}

    void Init(ref ResourceManager r) {
        resources = r;
    }

    public void UpdateResourceTimer() {
        updateTime += Time.deltaTime;

        if (updateTime >= .5f) {
            //GetResourceGenerators(gameObject.GetComponent<Base_gameobj>().baseData.buildings);
            //UpdateResources();
            updateTime -= .5f;
        }
    }

    // Refactor Needed!!!!
    /*

    public void UpdateResources() {
        foreach (Building building in resourceGenerators) {
            resources.energy += building.resourceGeneration[0];
            resources.metal += building.resourceGeneration[1];
        }
    }
    public void GetResourceGenerators(List<Building> allBuildings)
    {
        List<Building> generators = new List<Building>();

        foreach (Building building in allBuildings)
        {
			if (building.resourceGeneration.Length > 0) {
				if (building.resourceGeneration [0] > 0 || building.resourceGeneration [1] > 0) {
					generators.Add (building);
				}
			}
        }

        resourceGenerators = generators;
    }
	public void GetResourceCapacity(List<Building> allBuildings)
	{
		List<Building> capacity = new List<Building>();

		foreach (Building building in allBuildings)
		{
			if (building.resourceCapacity.Length > 0) {
				if (building.resourceCapacity [0] > 0 || building.resourceCapacity [1] > 0) {
					capacity.Add (building);
				}
			}
		}

		resourceCapacity = capacity;
	}

    */

}
