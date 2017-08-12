﻿using UnityEngine;
using UnityEngine.UI;

public class FactoryTaskButton : MonoBehaviour {

    public Image itemIcon;
    public Text itemName;
    public Text completion;

    public void Init(FactoryBuildTask task) {
        itemIcon = task.buildItem.icon as Image;
        itemName.text = task.buildItem.name;
        completion.text = (task.hoursContributed / (task.buildItem.buildHours * task.itemBuildAmount)).ToString();
    }
}