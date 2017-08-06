using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonistController : MonoBehaviour {
	
	public ColonistManager colonistManager;

	public float updateTime = 0f;

    // Use this for initialization
    void Start() {
        colonistManager = WorldController.Instance.world.baseData.colonistManager;
    }
	
	// Update is called once per frame
	void Update () {
		UpdateManHourTimer ();
	}

    //Timers
	public void UpdateManHourTimer() {
		updateTime += Time.deltaTime;

		if (updateTime >= 1f) {
			UpdateManHours ();
			updateTime -= 1f;
		}
	}
	public void UpdateManHours(){

		float timeValue = 1f / (24f * 10f);

		foreach( Colonist colonist in colonistManager.colonists ){
			
		}
	}

}
