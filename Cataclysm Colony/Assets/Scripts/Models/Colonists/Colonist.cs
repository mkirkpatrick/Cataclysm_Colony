using System.Collections;
using System.Collections.Generic;

[ System.Serializable ]
public class Colonist {

	public ColonistManager.JobType currentJobType;

	public float health;
	public float oxygenLevel; // 0 is no oxygen, 100 is normal earth sea level, 100+ is higher than normal levels.
	public float hunger; // 25-100 is normal energy level. 10-25 is hungry with slight performance decline. Below 10 is starving which causes great performance decline and illness.

    //[System.NonSerialized]
    public Building assignedBuilding;

    public Colonist() {
        health = 100f;
        oxygenLevel = 100f;
        hunger = 100f;
    }
}
