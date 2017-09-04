using UnityEngine;
using UnityEngine.UI;

public class FactoryTaskButton : MonoBehaviour {

    public Image itemIcon;
    public string itemName;
    public Text completion;

    public void Init(FactoryBuildTask task) {
        itemIcon.sprite = task.buildItem.icon;
        itemName = task.buildItem.name;
        completion.text = (task.hoursContributed / (task.buildItem.buildHours * task.itemBuildAmount)).ToString();
    }
}
