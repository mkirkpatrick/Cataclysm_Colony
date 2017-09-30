using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_gameobj : MonoBehaviour {

    public Building buildingData;
    public string uiObject;

    void Update() {
        if (buildingData.currentStatus == Building.BuildingStatus.UnderConstruction) {
            Vector3 newScale = new Vector3(15, 15 * (buildingData.constructedProgress / buildingData.totalConstructionHours),15);
            gameObject.transform.localScale = newScale;
        }
            
    }


    void OnMouseDown()
    {
            
        if (UIController.Instance.lockOtherInput == false)
            UIController.Instance.OpenUI(uiObject);

    }
}
