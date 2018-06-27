using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Album : MonoBehaviour
{
    public GameObject container;
    public GameObject uiItemPrefab;

    void Start()
    {
        for (int i = 0; i < ItemManager.Instance.items.itemList.Count; i++)
        {
            ItemUI itemUI = GameObject.Instantiate(uiItemPrefab).GetComponent<ItemUI>();
            itemUI.SetItem(ItemManager.Instance.items.itemList[i]);
            itemUI.transform.SetParent(container.transform, false);
        }
    }


	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GotoMenu();
        }
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
