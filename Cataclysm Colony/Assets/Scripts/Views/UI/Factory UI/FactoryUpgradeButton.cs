using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUpgradeButton : MonoBehaviour {

	public Item selectedItem;
	public int upgradeSelected;

    public Image upgradeIcon;

    public bool isSelected = false;

    public void Init(Item item, int upgradeNum)
    {
		selectedItem = item;
		upgradeSelected = upgradeNum;
		upgradeIcon.sprite = selectedItem.upgrades[upgradeSelected].icon;
    }

    public void UpgradeButtonAction()
    {
		UIController.Instance.factoryUI.factoryUIData.selectedUpgrade = upgradeSelected;
        UIController.Instance.factoryUI.UpdateDescription();
    }
}
