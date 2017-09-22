using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController Instance { get; protected set; }

    public PlayerStatusController psc;

    public DatabaseController databaseController;
    public WorldController worldController;
    public BaseController baseController;
    public ColonistController colonistController;
	public InventoryController inventoryController;
	public MouseController mouseController;


    void Awake(){

		if (Instance == null) // check to see if the instance has a reference
		{
            Instance = this; // if not, give it a reference to this class...
			DontDestroyOnLoad(Instance);
		}
		else Destroy(this.gameObject);


	}

	// Use this for initialization
	void Start () {
        worldController.CreateNewWorld();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
