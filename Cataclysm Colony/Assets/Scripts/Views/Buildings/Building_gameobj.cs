using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_gameobj : MonoBehaviour {

    public Building buildingData;
    public string uiObject;

    private Vector3 initialScale;

    void Awake() {
        initialScale = transform.localScale;
    }

    void Update() {
        if (buildingData.currentStatus == Building.BuildingStatus.UnderConstruction) {
            Vector3 newScale = new Vector3(initialScale.x, initialScale.y * (buildingData.constructedProgress / buildingData.totalConstructionHours), initialScale.z);
            gameObject.transform.localScale = newScale;
        }
            
    }


    void OnMouseDown()
    {

        if ( (UIController.Instance.lockOtherInput == false) && (buildingData.currentStatus == Building.BuildingStatus.Ready) )
            UIController.Instance.OpenUI(uiObject);

    }
}
