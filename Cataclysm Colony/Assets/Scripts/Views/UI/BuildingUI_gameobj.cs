using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI_gameobj : MonoBehaviour {

	public Building buildingData;

	public Text allocatedColonists;

	void OnEnable(){
		UpdateUI ();
	}

	void UpdateUI(){
		if (buildingData.allocatedColonists.Count > 0)
			allocatedColonists.text = buildingData.allocatedColonists.Count.ToString ();
		else
			allocatedColonists.text = "0";
	}

	public void AllocateColonist(){

		if (buildingData.allocatedColonists.Count < buildingData.totalColonistCapacity) {
			Colonist col = WorldController.Instance.world.baseData.colonistManager.GetIdleColonist();
			if (col != null) {
				WorldController.Instance.world.baseData.colonistManager.AllocateColonistToBuilding (col, buildingData);
				UpdateUI ();
			}
		}
	}
	public void DeallocateColonist(){

		if (buildingData.allocatedColonists.Count > 0) {
			Colonist col = buildingData.allocatedColonists [0];
			buildingData.allocatedColonists.RemoveAt(0);
			WorldController.Instance.world.baseData.colonistManager.SetIdleColonist(col);

			UpdateUI ();
		}

	}
}
