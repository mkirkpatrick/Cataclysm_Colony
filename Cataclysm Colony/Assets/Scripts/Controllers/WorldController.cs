using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    public static WorldController Instance { get; protected set; }

    public World world;

    void Awake(){
        if (Instance == null) // check to see if the instance has a reference
        {
            Instance = this; // if not, give it a reference to this class...
        }
        else Destroy(this.gameObject);

    }
	
	// Update is called once per frame
	void Update () {
      
    }

    public void CreateNewWorld() {
        world = new World(100, 100);
    }
}
