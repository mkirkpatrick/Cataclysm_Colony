using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public static UIController Instance;

    public bool lockOtherInput = false;

    public FactoryUI factoryUI;

	// Use this for initialization
	void Awake () {
		if (Instance == null) // check to see if the instance has a reference
		{
			Instance = this; // if not, give it a reference to this class...
			DontDestroyOnLoad(Instance);
		}
		else Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OpenUI(string UIName) {

        switch (UIName) {

            case "FactoryUI":
                factoryUI.gameObject.SetActive(true);
                break;

        }
    }
}
