using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryItemButton : MonoBehaviour
{

    public Image itemIcon;
    public Text itemName;

    public void Init(Item item)
    {
        itemIcon = item.icon as Image;
        itemName.text = item.name;
    }
}
