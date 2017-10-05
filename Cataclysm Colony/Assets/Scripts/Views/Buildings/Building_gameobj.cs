using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_gameobj : MonoBehaviour {

    public BaseController baseController;
    public Building buildingData;
    public string uiObject;


    public ProgressBarUI_gameobj constructionBar;


    private Vector3 initialScale;
    public bool showStatus = false;


    void Awake() {
        initialScale = transform.localScale;
    }
    protected virtual void Start() {
        baseController = GameController.Instance.baseController;
    }
    void Update() {
        CheckStatus();  
    }


    void OnMouseDown()
    {

        if ( (UIController.Instance.lockOtherInput == false) && (buildingData.currentStatus == Building.BuildingStatus.Ready) )
            UIController.Instance.OpenUI(uiObject);

    }

    public void CheckStatus() {

        showStatus = baseController.showBaseStatus;

        switch (buildingData.currentStatus) {
            case Building.BuildingStatus.UnderConstruction:
                UpdateConstruction();
                break;
        }
    }

    public void ShowBuildingStatus() {

        showStatus = true;

        if (buildingData.currentStatus == Building.BuildingStatus.UnderConstruction)
            constructionBar.gameObject.SetActive(true);

    }
    public void HideBuildingStatus()
    {
        showStatus = false;
        constructionBar.gameObject.SetActive(false);
    }

    public void UpdateConstruction() {
        if (showStatus == true) {
            constructionBar.slider.value = (buildingData.constructedProgress / buildingData.totalConstructionHours);
        }
            
    }
}
