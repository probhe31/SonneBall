using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public static DataManager Instance;
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }


    void Initialize()
    {
        if (!PlayerPrefs.HasKey("bestscore"))
        {
            PlayerPrefs.SetInt("bestscore", 0);
            PlayerPrefs.SetInt("ItemsUnlock", 0);            
        }
    }
    
}
