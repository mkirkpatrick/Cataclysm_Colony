using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController Instance { get; protected set; }

	public PlayerInfo playerInfo;
    public PlayerStatusController psc;
    public ColonistController colonist_Controller;
    public BaseController base_Controller;


	void Awake(){

		if (Instance == null) // check to see if the instance has a reference
		{
            Instance = this; // if not, give it a reference to this class...
			DontDestroyOnLoad(Instance);
		}
		else Destroy(this.gameObject);

        psc = GetComponent<PlayerStatusController>();

	}

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
