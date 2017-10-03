using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot_gameobj : MonoBehaviour {

    public Renderer rend;
    public Color plotHover;

    public Plot plotData;
    public Building_gameobj building_obj;

    public GameObject UIobject;
	public Plot_gameobj (){
		//plotData = new Plot (Plot.PlotType.Bunker, 0);
	}
	public Plot_gameobj (Plot pData){
		plotData = pData;
	}

    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.material.color = Color.clear;
    }

    void OnMouseEnter()
    {
        if (UIController.Instance.lockOtherInput == false)
            rend.material.color = plotHover;
    }

    void OnMouseExit()
    {
        if (UIController.Instance.lockOtherInput == false)
            rend.material.color = Color.clear;
    }

    void OnMouseDown() {
        if (UIController.Instance.lockOtherInput == false)
            UIController.Instance.OpenUI(building_obj.uiObject);
            
    }

}
