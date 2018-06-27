using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {

    public Text nameItem;
    public Text unlockAtItem;
    public Image imageItem;

    public void SetItem(Item item)
    {
        nameItem.text = item.itemName;
        unlockAtItem.text = ""+item.unlockAt;
        imageItem.sprite = item.sprite;

    }
	
}
