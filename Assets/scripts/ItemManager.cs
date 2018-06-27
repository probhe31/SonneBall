using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public ItemCollection items;
    public static ItemManager Instance;
    int currentMaxItemUnlock = 0;

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public int MaxItemUnlock(int value)
    {
        int nextIdItemUnlock = currentMaxItemUnlock + 1;

        if (nextIdItemUnlock == items.itemList.Count)
            return currentMaxItemUnlock;

        
        if (value >= items.itemList[nextIdItemUnlock].unlockAt)
            currentMaxItemUnlock = nextIdItemUnlock;

        return currentMaxItemUnlock;

        /*int maxItemUnlock = 0;
        for (int i = 0; i < items.itemList.Count; i++)
        {
            if (value > items.itemList[i].value)
                maxItemUnlock = i;
        }
        return maxItemUnlock;*/
    }

    public Ball RandomUnlockItem(int value, Vector3 position)
    {
        int random = Random.Range(0, MaxItemUnlock(value) + 1);
        return TrashMan.spawn(ItemManager.Instance.items.itemList[random].prefabName, position).GetComponent<Ball>();
    }
}
