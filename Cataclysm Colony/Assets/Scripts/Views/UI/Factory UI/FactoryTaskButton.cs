using UnityEngine;
using UnityEngine.UI;

public class FactoryTaskButton : MonoBehaviour {

    public FactoryBuildTask factoryTask;

    public Image itemIcon;
    public string itemName;
    public Text completion;

    public void Init(FactoryBuildTask task) {
        factoryTask = task;
        itemIcon.sprite = task.buildItem.icon;
        itemName = task.buildItem.name;
        //completion.text = (task.hoursContributed / (task.buildItem.buildHours * task.itemBuildAmount)).ToString();
    }

    void Update() {
        //completion.text = (factoryTask.hoursContributed / (factoryTask.buildItem.buildHours * factoryTask.itemBuildAmount)).ToString();
        completion.text = factoryTask.GetHoursRemaining().ToString("F1");
    }

    public void TaskButtonAction() { 
        UIController.Instance.factoryUI.ResetUIData();
        UIController.Instance.factoryUI.factoryUIData = new FactoryUIData(factoryTask);
        UIController.Instance.factoryUI.ShowSelectedTask();
    }
}
