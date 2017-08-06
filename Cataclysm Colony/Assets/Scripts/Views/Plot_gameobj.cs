using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot_gameobj : MonoBehaviour {

    public Renderer rend;
    public Color plotHover;

    public Plot plotData;
    public Building_gameobj building_obj;

    public GameObject UIobject;

    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.material.color = Color.clear;
    }

    void OnMouseEnter()
    {
        rend.material.color = plotHover;
    }

    void OnMouseExit()
    {
        rend.material.color = Color.clear;
    }

    void OnMouseDown() {
        Debug.Log(building_obj.buildingData.buildingName);
    }

}
