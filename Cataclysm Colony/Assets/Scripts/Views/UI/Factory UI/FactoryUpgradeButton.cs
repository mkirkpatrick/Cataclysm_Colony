using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryUpgradeButton : MonoBehaviour {

    public ItemUpgrade buttonUpgrade;

    public Image upgradeIcon;

    public bool isSelected = false;

    public void Init(ItemUpgrade upgrade)
    {
        buttonUpgrade = upgrade;
        upgradeIcon.sprite = buttonUpgrade.icon;
    }

    public void UpgradeButtonAction()
    {
        UIController.Instance.factoryUI.factoryUIData.selectedUpgrade = buttonUpgrade;
        UIController.Instance.factoryUI.UpdateDescription();
    }
}
