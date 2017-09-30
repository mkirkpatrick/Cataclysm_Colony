using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI_gameobj : MonoBehaviour {

	public Building buildingData;

	public Text allocatedColonists;

    void Update() {
        
    }

	void OnEnable(){
		UpdateUI ();
	}

	void UpdateUI(){
		if (buildingData.allocatedColonists.Count > 0)
			allocatedColonists.text = buildingData.allocatedColonists.Count.ToString ();
		else
			allocatedColonists.text = "0";
	}
}
