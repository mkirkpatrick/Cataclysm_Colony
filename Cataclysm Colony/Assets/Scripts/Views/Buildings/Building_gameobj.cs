using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_gameobj : MonoBehaviour {

    public Building buildingData;
    public string uiObject;


    void OnMouseDown()
    {
            
        if (UIController.Instance.lockOtherInput == false)
            UIController.Instance.OpenUI(uiObject);

    }
}
