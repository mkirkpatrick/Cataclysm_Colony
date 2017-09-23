using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionController : MonoBehaviour {

	public List<Building> constructionList;

	public void Update(){
		UpdateConstruction ();
	}

	public void UpdateConstruction(){
		foreach (Building building in constructionList) {
			building.contructionProgress += building.allocatedColonists.Count * Time.deltaTime / 60f;
		}
	}
}
