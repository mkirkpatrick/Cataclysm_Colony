using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_gameobj : MonoBehaviour {

	public Base baseData;
    public BaseController bc;
    public ResourceController rc;
    public BuildController builder;
	public ColonistController cc;

	// Use this for initialization
	void Awake () {
		
    }

	void Start(){
        baseData = WorldController.Instance.world.baseData;
	}
}
