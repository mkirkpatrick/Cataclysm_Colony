﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryItemButton : MonoBehaviour
{

    public Item buttonItem;

    public Image itemIcon;
    public Text itemName;

    public bool isSelected = false;

    public void Init(Item item)
    {
        buttonItem = item;
        itemIcon.sprite = buttonItem.icon;
        itemName.text = buttonItem.name;
    }

    public void ItemButtonAction() {
        UIController.Instance.factoryUI.ResetUIData();
        UIController.Instance.factoryUI.factoryUIData = new FactoryUIData(buttonItem);
        UIController.Instance.factoryUI.ShowSelectedItem();
    }
}
