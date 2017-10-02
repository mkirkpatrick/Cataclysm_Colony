using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public float gameClock = 0f;
    public float timeMultiplier = 1f;

    public int currentDay = 1;
    public float currentTime = 6f;
    public int hours;
    public float minutes;

    public bool isDaytime = true;
    public bool isPaused = false;

	void Start () {
		ChangeTimeScale (4f); //Start clock at 4x time
	}
	
	void Update () {

		//Quick key clock speed changes
		if (Input.GetKeyDown (KeyCode.Alpha1))
			ChangeTimeScale (4);
		else if (Input.GetKeyDown (KeyCode.Alpha2))
			ChangeTimeScale (8);
		else if (Input.GetKeyDown (KeyCode.Alpha3))
			ChangeTimeScale (12);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeTimeScale(16);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeTimeScale(20);

        if (isPaused != true) {
            UpdateClocks();
        }
    }

    public void UpdateClocks() {
        float startTime = gameClock;
        gameClock += Time.deltaTime;

        float timeChange = gameClock - startTime;
        currentTime += timeChange;

            minutes += timeChange;
        if (minutes >= 60) {
            //Check for 6am day change
            if (hours == 5)
                currentDay++;
            minutes -= 60;
            hours++;
        }

        if (hours >= 24) {
            hours -= 24;
        }
        
    }

	public void ChangeTimeScale(float timeScale){
		Time.timeScale = timeScale;
	}
}
