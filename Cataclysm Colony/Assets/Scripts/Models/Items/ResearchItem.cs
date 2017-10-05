﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchItem {

    public enum ResearchType { Energy, Structural, Medical, Sensory, Weaponry, Robotics}

    public int id = 0;
    public string name = "";
    public string description = "";
    public int[] requiredResearch = { };
    public int totalHours = 100;

    public ResearchItem() {

    }
}