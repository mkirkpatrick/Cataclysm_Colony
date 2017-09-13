using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryButton : MonoBehaviour {

	public Item item;

	public Text itemCountText;
	public Image itemIcon;

	public void Init(Item item, int count){
		itemIcon.sprite = item.icon;
		itemCountText.text = count.ToString();
	}
}
