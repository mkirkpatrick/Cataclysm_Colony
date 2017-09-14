using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {

    public BaseController baseController;
    public TimeController timeController;

    //Time
    public Text currentTime;
    public Text dayText;

    //Colonists
    public Text totalColonistText;
    public Text availableColonistText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Time
        string minutes = Mathf.FloorToInt(timeController.minutes).ToString();
        if (timeController.minutes < 10)
            minutes = "0" + minutes;
        currentTime.text = timeController.hours.ToString() + ":" + minutes.ToString();

        dayText.text = timeController.currentDay.ToString(); 

        //Colonists
        totalColonistText.text = baseController.baseData.colonists.Count.ToString();
        availableColonistText.text = baseController.baseData.idleColonists.Count.ToString();
	}
}
